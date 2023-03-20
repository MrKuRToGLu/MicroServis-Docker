
1) Ocelot package indirilir...

2) Projenin ana dizinine Ocelot isimli bir json dosyası eklenir..

https://ocelot.readthedocs.io/en/latest/introduction/gettingstarted.html adresinden aşağıdaki bölüm alınarak ocelot.json dosyasına eklenir;
{
    "Routes": [
        {
        "DownstreamPathTemplate": "/todos/{id}", -- yölendirme yapılacak rota
        "DownstreamScheme": "http",
        "DownstreamHostAndPorts": [ -- host bilgileri 
            {
                "Host": "jsonplaceholder.typicode.com",
                "Port": 443
            }
        ],
        "UpstreamPathTemplate": "/todos/{id}", -- istek yapılan rota
        "UpstreamHttpMethod": [ "Get" ]
        }
    ],
    "GlobalConfiguration": { -- gateway uygulamanızın ayarları, 
        "BaseUrl": "https://localhost:5000" --gateway uygulamasının adresi...
    }
}

2) Program.cs dosyasında gerekli configurassyonlar yapılır;
builder.Configuration.AddJsonFile("Ocelot.json");
builder.Services.AddOcelot(); dependency injection...
app.UseOcelot(); => middleware

3) Ocelot configurasyonunda portları eklerken ilgili servis projesine gidip properties klasörü altından launchSettings.json dosyasından iisexpress veya profiles düğümlerinden portlar öğrenilebilir....
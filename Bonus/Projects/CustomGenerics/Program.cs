﻿using Cache;

var cacheManager = new CacheService<Announcment>(); // CacheService sınıfının T kullanan üyeleri Announcment tipi ile çalışacaktır
var anno1 = new Announcment
{
    Id = 1,
    Title = "The Matriks",
    Content = @"
            <html>
                <title>The Matriks I</title>
                <body>
                    <div>
                        Some thoughts...
                    </div>
                </body>
            </html>
            "
};

cacheManager.Set("MatriksAnno", anno1);
var cached = cacheManager.Get("MatriksAnno");
Console.WriteLine(cached.Title);
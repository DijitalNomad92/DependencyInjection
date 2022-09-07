
ILogger logger = new FileLogger();
UrunService service = new UrunService(logger);
service.Ekle();

KategoriService kategoriService = new KategoriService()
{
    Logger = new EventLogger()
};
MagazaService magazaService = new MagazaService();
magazaService.Sil(new EventLogger());


class UrunService // urun'u  eklemek için class ve Logger üzerinden buraya log çekeriz
{
    private readonly ILogger _logger;

    public UrunService(ILogger logger)  // constructor injection
    {
        _logger = logger;
    }

    public void Ekle()
    {
        Console.WriteLine("Ürün Eklendi");  
        _logger.Log();

    }
}

class KategoriService // property injection  
{
    public ILogger Logger { get; set; } // ozellikle log işlemi yapıyoruz
    public void Guncelle()
    {
        Console.WriteLine("Kategori guncellendi");
        Logger.Log();
    }
}

class MagazaService  // method injection
{
    public void Sil(ILogger logger) // method'la log işleni yapıyoruz
    {
        Console.WriteLine("Magaza silindi");
        logger.Log();
    }
}



interface ILogger // log ınterface yukarıda log'lamak için 
{
    void Log();
}

class FileLogger : ILogger
{
    public void Log()
    {
        Console.WriteLine("Logged to file");
    }
}

class DatabaseLogger : ILogger
{
    public void Log()
    {
        Console.WriteLine("Logged to database");
    }
}

class EventLogger : ILogger  // event log kullanım ornegi
{
    public void Log()
    {
        Console.WriteLine("Logged to Windows Event Log");
    }
}

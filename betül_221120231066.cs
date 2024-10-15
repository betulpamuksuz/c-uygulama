using System;
using System.Collections.Generic;

class Kitap
{
    public string KitapAdi { get; set; }
    public string YazarAdi { get; set; }
    public string ISBN { get; set; }
    public int YayinYili { get; set; }

    public Kitap(string kitapAdi, string yazarAdi, string isbn, int yayinYili)
    {
        KitapAdi = kitapAdi;
        YazarAdi = yazarAdi;
        ISBN = isbn;
        YayinYili = yayinYili;
    }

    public override string ToString()
    {
        return $"Kitap Adı: {KitapAdi}, Yazar: {YazarAdi}, ISBN: {ISBN}, Yayın Yılı: {YayinYili}";
    }
}

class Kutuphane
{
    private List<Kitap> kitaplar;

    public Kutuphane()
    {
        kitaplar = new List<Kitap>();
    }

    // Kitap Ekleme Metodu
    public void KitapEkle()
    {
        Console.Write("\nKitap Adı: ");
        string kitapAdi = Console.ReadLine();

        Console.Write("Yazar Adı: ");
        string yazarAdi = Console.ReadLine();

        Console.Write("ISBN: ");
        string isbn = Console.ReadLine();

        Console.Write("Yayın Yılı: ");
        int yayinYili = int.Parse(Console.ReadLine());

        Kitap yeniKitap = new Kitap(kitapAdi, yazarAdi, isbn, yayinYili);
        kitaplar.Add(yeniKitap);

        Console.WriteLine("\nKitap başarıyla eklendi!\n");
    }

    // Kitapları Listeleme Metodu
    public void KitaplariListele()
    {
        if (kitaplar.Count == 0)
        {
            Console.WriteLine("\nKütüphanede hiç kitap yok!\n");
            return;
        }

        Console.WriteLine("\nKütüphanedeki Kitaplar:");
        foreach (var kitap in kitaplar)
        {
            Console.WriteLine(kitap);
        }
        Console.WriteLine();
    }

    // Kitap Arama Metodu
    public void KitapAra()
    {
        Console.Write("\nAramak istediğiniz kitabın adını girin: ");
        string aranan = Console.ReadLine();

        var bulunanKitaplar = kitaplar.FindAll(k => k.KitapAdi.ToLower().Contains(aranan.ToLower()));

        if (bulunanKitaplar.Count > 0)
        {
            Console.WriteLine("\nAranan Kitap(lar):");
            foreach (var kitap in bulunanKitaplar)
            {
                Console.WriteLine(kitap);
            }
        }
        else
        {
            Console.WriteLine("\nKitap bulunamadı.\n");
        }
    }

    // Kitap Silme Metodu
    public void KitapSil()
    {
        Console.Write("\nSilmek istediğiniz kitabın ISBN numarasını girin: ");
        string isbn = Console.ReadLine();

        Kitap silinecekKitap = kitaplar.Find(k => k.ISBN == isbn);

        if (silinecekKitap != null)
        {
            kitaplar.Remove(silinecekKitap);
            Console.WriteLine("\nKitap başarıyla silindi!\n");
        }
        else
        {
            Console.WriteLine("\nKitap bulunamadı.\n");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Kutuphane kutuphane = new Kutuphane();
        bool cikis = false;

        while (!cikis)
        {
            Console.WriteLine("--- Kütüphane Yönetim Sistemi ---");
            Console.WriteLine("1. Kitap Ekle");
            Console.WriteLine("2. Kitapları Listele");
            Console.WriteLine("3. Kitap Ara");
            Console.WriteLine("4. Kitap Sil");
            Console.WriteLine("5. Çıkış");
            Console.Write("Seçiminizi yapın: ");
            string secim = Console.ReadLine();

            switch (secim)
            {
                case "1":
                    kutuphane.KitapEkle();
                    break;
                case "2":
                    kutuphane.KitaplariListele();
                    break;
                case "3":
                    kutuphane.KitapAra();
                    break;
                case "4":
                    kutuphane.KitapSil();
                    break;
                case "5":
                    cikis = true;
                    Console.WriteLine("\nÇıkış yapılıyor...");
                    break;
                default:
                    Console.WriteLine("\nGeçersiz seçim, tekrar deneyin.\n");
                    break;
            }
        }
    }
}

namespace APBD_CW3;

public abstract class Kontener
{
    public double MasaLadunku { get; set; }
    public double Wysokosc { get; }
    public double WagaWlasna { get; }
    public double Glebokosc { get; }
    public string NumerSeryjny { get; set; }
    public double MaksymalnaLadownosc { get; }
    public double WagaCalkowita => MasaLadunku + WagaWlasna;
    public string Oznaczenie { get; set; }
    
    private static int ID = 1;


    protected Kontener(double masaLadunku, double wysokosc, double wagaWlasna, double glebokosc, double maksymalnaLadownosc, string oznaczenie)
    {
        MasaLadunku = masaLadunku;
        Wysokosc = wysokosc;
        WagaWlasna = wagaWlasna;
        Glebokosc = glebokosc;
        MaksymalnaLadownosc = maksymalnaLadownosc;
        Oznaczenie = oznaczenie;
        NumerSeryjny = $"KON-{Oznaczenie}-{ID++}";
    }

    public void OproznijLadunek()
    {
        MasaLadunku = 0;
        Console.WriteLine("Oprozniono ladunek dla kontenera: " + NumerSeryjny);
    }

    public void ZaladujKontener(double masaLadunku)
    {
        if (MasaLadunku + masaLadunku > MaksymalnaLadownosc)
        {
            throw new OverfillException();
        }
        
        MasaLadunku += masaLadunku;
        Console.WriteLine("Zaladowano kontener: " + NumerSeryjny + " o masie: " + masaLadunku);
    }
    
    public void WyswietlInformacje()
    {
        Console.WriteLine("\nNumer seryjny: " + NumerSeryjny);
        Console.WriteLine("Masa ladunku: " + MasaLadunku + " kg");
        Console.WriteLine("Wysokosc: " + Wysokosc + " cm");
        Console.WriteLine("Glebokosc: " + Glebokosc + " cm");
        Console.WriteLine("Waga wlasna: " + WagaWlasna + " kg");
        Console.WriteLine("Maksymalna ladownosc: " + MaksymalnaLadownosc + " kg");
        Console.WriteLine("Waga calkowita: " + WagaCalkowita + " kg");
    }
}
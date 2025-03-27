namespace APBD_CW3;

public class Statek
{
    public  List<Kontener> Kontenery { get; set; } = new List<Kontener>();
    public double MaksymalnaPredkosc { get; set; }
    public int MaksymalnaLiczbaKontenerow { get; set; }
    public double MaksymalnaMasaKontenerow { get; set; }
    private static int ID;

    public Statek(double maksymalnaPredkosc, int maksymalnaLiczbaKontenerow, double maksymalnaMasaKontenerow)
    {
        MaksymalnaPredkosc = maksymalnaPredkosc;
        MaksymalnaLiczbaKontenerow = maksymalnaLiczbaKontenerow;
        MaksymalnaMasaKontenerow = maksymalnaMasaKontenerow  * 1000;
        ID++;
    }

    private double ObliczSumeWagKontenerow()
    {
        double suma = 0;
        foreach (var k in Kontenery)
        {
            suma += k.WagaCalkowita;
        }
        return suma;
    }

    public void ZaladujKontener(Kontener kontener)
    {
        if (Kontenery.Count >= MaksymalnaLiczbaKontenerow)
        {
            throw new OverfillException();
        }

        double sumaWag = ObliczSumeWagKontenerow();
        if (sumaWag + kontener.WagaCalkowita > MaksymalnaMasaKontenerow)
        {
            throw new OverfillException();
        }

        Kontenery.Add(kontener);
    }

    public void ZaladujListeKontenerow(List<Kontener> listaKontenerow)
    {
        foreach (var kontener in listaKontenerow)
        {
            try
            {
                ZaladujKontener(kontener);
            } 
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
    
    public void UsunKontener(Kontener kontener)
    {
        if (Kontenery.Contains(kontener))
        {
            Kontenery.Remove(kontener);
        }
        else
        {
            throw new Exception("Kontener nie istnieje.");
        }
    }

    public void ZastapKontener(string numerSeryjny, Kontener nowyKontener)
    {
        var kontenerDoZastapienia = Kontenery.FirstOrDefault(k => k.NumerSeryjny == numerSeryjny);
        if (kontenerDoZastapienia != null)
        {
            try
            {
                UsunKontener(kontenerDoZastapienia);
                ZaladujKontener(nowyKontener);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Blad podczas zastepowania kontenera: ");
            }
        }
        else
        {
            Console.WriteLine("Nie znaleziono kontenera o numerze seryjnym: " + numerSeryjny);
        }
    }
    
    public void WyswietlInformacje()
    {
        Console.WriteLine("\nInformacje o statku nr " + ID);
        Console.WriteLine("Maksymalna prędkość: " + MaksymalnaPredkosc + " wezlow");
        Console.WriteLine("Maksymalna liczba kontenerów: " + MaksymalnaLiczbaKontenerow);
        Console.WriteLine("Maksymalna masa kontenerów: " + (MaksymalnaMasaKontenerow / 1000) + " t");
        Console.WriteLine("Aktualna liczba kontenerów: " + Kontenery.Count);

        double sumaWag = ObliczSumeWagKontenerow();
        Console.WriteLine("Aktualna masa kontenerów: " + (sumaWag / 1000) + " t");

        Console.WriteLine("\nSzczegóły kontenerów:");
        foreach (var kontener in Kontenery)
        {
            kontener.WyswietlInformacje();
        }
    }

}


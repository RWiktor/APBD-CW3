using System.ComponentModel.Design;

namespace APBD_CW3;

public class KontenerPlyny : Kontener, IHazardNotifier
{
    public bool czyNiebezpieczny { get; set; }

    public KontenerPlyny(double masaLadunku, double wysokosc, double wagaWlasna, double glebokosc, double maksymalnaLadownosc, bool czyNiebezpieczny) : base(masaLadunku, wysokosc, wagaWlasna, glebokosc, maksymalnaLadownosc, "L")
    {
        this.czyNiebezpieczny = czyNiebezpieczny;
    }

    public void WyslijNotyfikacje()
    {
        Console.WriteLine("UWAGA! Wystąpiła niebezpieczna sytuacja dla kontenera: " + NumerSeryjny);
    }
    
    public void ZaladujKontener(double masaLadunku)
    {
        double limit = czyNiebezpieczny ? MaksymalnaLadownosc * 0.5 : MaksymalnaLadownosc * 0.9;
        
        if (MasaLadunku + masaLadunku > limit)
        {
            WyslijNotyfikacje();
            throw new OverfillException("Przekroczono dozwolony poziom napełnienia.");
        }
        
        base.ZaladujKontener(masaLadunku);
    }

    
    
}
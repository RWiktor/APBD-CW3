namespace APBD_CW3;

public class KontenerChlodniczy : Kontener
{
    public string RodzajProduktu { get; set; }
    public double Temperatura { get; set; }

    public KontenerChlodniczy(double masaLadunku, double wysokosc, double wagaWlasna, double glebokosc, double maksymalnaLadownosc, string rodzajProduktu, double temperatura) : base(masaLadunku, wysokosc, wagaWlasna, glebokosc, maksymalnaLadownosc, "C")
    {
        RodzajProduktu = rodzajProduktu;
        Temperatura = temperatura;
    }
    
    public void ZaladujKontener(double masaLadunku, string rodzajLadunku, double temperaturaLadunku)
    {
        if (rodzajLadunku != RodzajProduktu || temperaturaLadunku > Temperatura)
        {
            throw new Exception("Produkt nie pasuje do kontenera.");
        }
        base.ZaladujKontener(masaLadunku);
    }
}
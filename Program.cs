using APBD_CW3;

class Program
{
    static void Main(string[] args)
    {
        KontenerGaz kontenerGaz = new KontenerGaz(0, 300, 20, 300, 1000, 100);
        KontenerChlodniczy kontenerChlodniczy = new KontenerChlodniczy(0, 100, 200, 30, 1000, "Ser", 7.2);
        KontenerPlyny kontenerPlyny = new KontenerPlyny(0, 200, 20, 250, 1000, true);
        Statek statek1 = new Statek(10, 1000, 2);
        Statek statek2 = new Statek(10, 1000, 2);

        kontenerGaz.ZaladujKontener(200);
        kontenerChlodniczy.ZaladujKontener(200, "Ser", 7.2);
        kontenerPlyny.ZaladujKontener(100);

        statek1.ZaladujKontener(kontenerGaz);
        List<Kontener> listaKontenerow = new List<Kontener> { kontenerChlodniczy, kontenerPlyny };
        statek1.ZaladujListeKontenerow(listaKontenerow);

        statek1.WyswietlInformacje();
        statek1.UsunKontener(kontenerPlyny);
        kontenerGaz.OproznijLadunek();

        KontenerChlodniczy nowyKontenerChlodniczy = new KontenerChlodniczy(50, 100, 20, 300, 1000, "Piwo", 15);
        statek1.ZastapKontener(kontenerChlodniczy.NumerSeryjny, nowyKontenerChlodniczy);

        TransferKontenera.PrzeniesKontener(statek1, statek2, nowyKontenerChlodniczy);

        kontenerGaz.WyswietlInformacje();
        kontenerChlodniczy.WyswietlInformacje();
        statek1.WyswietlInformacje();
        statek2.WyswietlInformacje();
    }
}
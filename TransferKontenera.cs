namespace APBD_CW3;

public class TransferKontenera
{
    public static void PrzeniesKontener(Statek statekZrodlowy, Statek statekDocelowy, Kontener kontener)
    {
        try
        {
            statekZrodlowy.UsunKontener(kontener);
            statekDocelowy.ZaladujKontener(kontener);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Wystąpił błąd podczas przenoszenia: ");
        }
    }
}
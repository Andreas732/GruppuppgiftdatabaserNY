using Gruppuppgiftdatabaser;
using System;

namespace Gruppuppgiftdatabaser;

public class Loan
{
    public int LoanID { get; set; }  // Primärnyckel
    public int UserID { get; set; }  // Utlånad till vilken användare
    public int BookID { get; set; }  // Vilken bok som är utlånad
    public DateTime LoanDate { get; set; }  // Datum då boken lånades
    public DateTime? ReturnDate { get; set; }  // Datum då boken återlämnades (kan vara null om boken inte har återlämnats)

    // Navigation Properties
    public User User { get; set; }  // Navigation till User (den som lånat boken)
    public Book Book { get; set; }  // Navigation till Book (den bok som lånades)
}

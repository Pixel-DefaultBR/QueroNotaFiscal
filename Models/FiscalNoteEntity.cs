using System.ComponentModel.DataAnnotations.Schema;

[Table("fiscalnotes")]
public class FiscalNoteEntity
{
    public int FiscalNoteId { get; set; }

    public string FiscalNoteNumber { get; set; }

    public decimal TotalValue { get; set; }

    public DateTime IssueDate { get; set; } = DateTime.UtcNow;

    public string CNPJIssuing { get; set; }

    public string CNPJRecipent { get; set; }

    public FiscalNoteEntity() { }
    public FiscalNoteEntity(string fiscalNoteNumber, decimal totalValue, string CnpjIssuing, string CnpjRecipent)
    {
        FiscalNoteNumber = fiscalNoteNumber;
        TotalValue = totalValue;
        CNPJIssuing = CnpjIssuing;
        CNPJRecipent = CnpjRecipent;
    }
}

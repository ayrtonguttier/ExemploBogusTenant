namespace Domain.DataTransferObjects;

public class Cliente
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string NomeRazaoSocial { get; set; } = string.Empty;
    public string NomeFantasia { get; set; } = string.Empty;
    public string Documento { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}
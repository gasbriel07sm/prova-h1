using System.ComponentModel.DataAnnotations;

public class Jogador
{
    [Required(ErrorMessage = "O nome é obrigatório.")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "O nome deve ter entre 3 e 50 caracteres.")]
    public string Nome { get; set; } = string.Empty;

    [Required(ErrorMessage = "O CPF é obrigatório.")]
    [RegularExpression(@"^\d{11}$" ,ErrorMessage = "O CPF deve ter 11 números")]
    public string CPF { get; set; } = string.Empty;

    [Required(ErrorMessage = "A descrição é obrigatória.")]
    [StringLength(500, ErrorMessage = "A descrição da proposta deve ter no máximo 500 caracteres.")]
    public string Descricao { get; set; } = string.Empty;

    [Required(ErrorMessage = "O número do candidato é obrigatório.")]
    [AllowedValues("GL","ZA","LD", "LE", "VO", "MD", "AT")]
    public string Posicao { get; set; } = string.Empty;

    public bool Approved { get; set; }
}


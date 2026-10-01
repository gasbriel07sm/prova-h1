using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("[controller]")]
public class JogadorController : ControllerBase
{
    private readonly IJogadorRepository _jogadorRepository;

    public JogadorController(IJogadorRepository jogadorRepository) => _jogadorRepository = jogadorRepository;


    [HttpPost]
    public IActionResult Cadastrar([FromBody] Jogador jogador)
    {
        if(!ModelState.IsValid) return BadRequest(ModelState);

        var cpf = jogador.CPF;
        if(_jogadorRepository.Existe(cpf)) 
            return Conflict(new { mensagem = $"Já existe um registro com o cpf {cpf}."});
        
        _jogadorRepository.Adicionar(jogador);
        
        return CreatedAtAction(nameof(BuscarPorCPF), new { cpf }, jogador);
    }

    [HttpGet]
    public IActionResult BuscarTodos() =>
    Ok(_jogadorRepository.BuscarTodos());

    [HttpGet("{cpf}")]
    public IActionResult BuscarPorCPF(string cpf)
    {
        var jogador = _jogadorRepository.BuscarPorCPF(cpf);
        if (jogador is null) return NotFound(new { mensagem = $"Nenhum jogador com o cpf {cpf}." });

        return Ok(jogador);
    }

    [HttpPut("{cpf}/resultado")]
    public IActionResult RegistrarResultado(string cpf, [FromQuery] bool aprovado)
    {
        var jogador = _jogadorRepository.BuscarPorCPF(cpf);

        if (jogador is null) return NotFound(new { mensagem = $"Nenhum jogador com o cpf {cpf}." });

        jogador.Approved = aprovado;

        return Ok(jogador);
    }

    [HttpGet("aprovados")]
    public IActionResult ConsultarAprovados() => Ok(_jogadorRepository.Aprovados());
}


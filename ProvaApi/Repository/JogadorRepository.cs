public class JogadorRepository : IJogadorRepository
{
    private readonly List<Jogador> _jogadores = new();

    public void Adicionar(Jogador jogador)
    {
        _jogadores.Add(jogador);
    }
    
    public IEnumerable<Jogador> BuscarTodos() => _jogadores;
    
    public IEnumerable<Jogador> Aprovados() => _jogadores.Where(jogador => jogador.Approved).ToList();

    public Jogador? BuscarPorCPF(string cpf) => _jogadores.FirstOrDefault(i => i.CPF == cpf);

    public bool Existe(string cpf) => _jogadores.Any(i => i.CPF == cpf);
}


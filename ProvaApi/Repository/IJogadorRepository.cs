public interface IJogadorRepository { 
    void Adicionar(Jogador jogador); 
    IEnumerable<Jogador> Aprovados(); 
    IEnumerable<Jogador> BuscarTodos(); 
    Jogador? BuscarPorCPF(string cpf); 
    bool Existe(string cpf); 
}

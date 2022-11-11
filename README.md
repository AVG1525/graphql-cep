# graphql-cep

Rodar a aplicação (.Net 6) e acessar o path: /ui/playground.
Por exemplo: https://localhost:7003/ui/playground

Query:

query {
  getCep(cep: "cep_que_deseja_buscar") {
    cep,
    uF,
    bairro,
    logradouro,
    localidade
  }
}
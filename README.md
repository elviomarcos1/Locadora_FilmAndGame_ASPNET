# Biblioteca de Filmes e Jogos

Este projeto é uma aplicação web desenvolvida com ASP.NET e C# utilizando a arquitetura MVC. A proposta é fornecer uma plataforma para gerenciar e exibir uma biblioteca de filmes e jogos, permitindo ao usuário visualizar, adicionar, editar e excluir itens da coleção.

## Funcionalidades

- **Exibição de Filmes e Jogos:** O usuário pode visualizar os itens cadastrados, com informações detalhadas como título, descrição, ano de lançamento, e categoria.
- **Cadastro de Filmes e Jogos:** Adicionar novos filmes e jogos à biblioteca, com informações detalhadas.
- **Edição de Filmes e Jogos:** Editar as informações de itens cadastrados.
- **Exclusão de Itens:** Remover filmes e jogos da biblioteca.
- **Organização por Categorias:** Organizar filmes e jogos em categorias (como ação, comédia, RPG, etc.).

## Tecnologias Utilizadas

- **ASP.NET MVC:** Framework para construção da aplicação web.
- **C#:** Linguagem de programação utilizada no backend.
- **SQLite:** Banco de dados para armazenar informações de filmes e jogos.
- **Entity Framework:** ORM (Object-Relational Mapping) para interagir com o banco de dados.
- **Bootstrap:** Framework CSS para o design responsivo da interface do usuário.

## Arquitetura

A aplicação segue o padrão de arquitetura **MVC (Model-View-Controller)**:

- **Model:** Representa os dados da aplicação (Filmes, Jogos, etc.) e a lógica de acesso a dados.
- **View:** Responsável pela interface do usuário, exibindo os dados e permitindo interação com o sistema.
- **Controller:** Gerencia as requisições do usuário, manipula os dados e retorna a resposta (geralmente, renderizando uma View).

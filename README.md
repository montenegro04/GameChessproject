# ♟️ Console Chess (C#)

Sistema completo de jogo de xadrez desenvolvido em C# e .NET, executado diretamente no console. Este projeto foca na aplicação prática de **Lógica de Programação** e **Programação Orientada a Objetos (POO)**, implementando todas as regras oficiais do jogo.

## 📋 Sobre o Projeto

Trata-se de uma aplicação baseada em console que simula uma partida de xadrez. O objetivo principal foi construir uma arquitetura robusta, capaz de validar movimentos complexos e gerenciar o estado da partida turno a turno.

O sistema realiza o tratamento de exceções para impedir movimentos ilegais e garante a aderência estrita às regras do xadrez.

## ⚙️ Funcionalidades e Regras Implementadas

O jogo vai além da movimentação básica, suportando jogadas especiais e detecção de estados críticos:

* **Sistema de Turnos:** Controle automático do jogador atual (Brancas/Pretas).
* **Interface Visual:** * Peças Brancas: Exibidas em **Branco**.
    * Peças Pretas: Exibidas em **Amarelo** (para melhor visibilidade em terminais escuros).
* **Jogadas Especiais:**
    * ✅ **Roque:** Pequeno (ala do rei) e Grande (ala da dama).
    * ✅ **En Passant:** Captura especial de peão.
    * ✅ **Promoção:** Transformação do peão ao atingir a última fileira.
* **Estados de Jogo:** Detecção automática de **Xeque** e **Xequemate**, encerrando a partida conforme necessário.

## 📂 Estrutura do Projeto

O projeto está organizado em duas camadas principais para garantir a separação de responsabilidades:

* **Camada de Tabuleiro:** Gerencia a lógica genérica do tabuleiro, peças e posicionamento (reutilizável para outros jogos de tabuleiro).
* **Camada de Xadrez:** Implementa as regras específicas do xadrez, jogadas especiais e a lógica da partida.

## 🛠 Tecnologias e Conceitos

* **C#**
* **.NET**
* **POO:** Encapsulamento, Herança, Polimorfismo e Sobrecarga.
* **Matrizes:** Lógica de posicionamento em grade bidimensional.
* **Tratamento de Exceções:** Proteção contra entradas inválidas do usuário.

## 🚀 Como Executar

**Pré-requisito:** .NET SDK instalado.

1.  **Clonar o repositório:**
    ```bash
    git clone [https://github.com/montenegro04/GameChessproject](https://github.com/montenegro04/GameChessproject)
    ```
2.  **Navegar até a pasta do projeto:**
    ```bash
    cd GameChessproject
    ```
3.  **Executar a aplicação:**
    ```bash
    dotnet run
    ```

## 👨‍💻 Autor

**Gustavo Palmeira Montenegro** Estudante de Engenharia de Controle e Automação - UFPel

## 🔮 Melhorias Futuras

- [ ] Implementar uma Inteligência Artificial (IA) para o modo contra o computador.
- [ ] Adicionar um painel de "cemitério" para visualização das peças capturadas.
- [ ] Criar um sistema de persistência para Salvar/Carregar partidas.
- [ ] Desenvolver uma interface gráfica Web utilizando HTML, CSS e JavaScript.
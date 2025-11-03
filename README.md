## Desafio Back-End da Frota Estelar 🚀

**Para:** Cadete Yan
**De:** Comando da Frota Estelar, Divisão de Arquitetura de Software
**Assunto:** Desenvolvimento do Sistema Oficial de Gerenciamento da Frota (SOGF)

![jabba](./assets/jabba.png)

### 1. Visão Geral da Missão (O Desafio)

Bem-vindo à Frota Estelar, Cadete.

Sua primeira missão é desenvolver a espinha dorsal de nosso novo **Sistema Oficial de Gerenciamento da Frota (SOGF)**. Este sistema é crítico para nossas operações, permitindo ao Comando rastrear ativos, gerenciar pessoal e registrar dados táticos vitais.

O SOGF será uma **API RESTful** que servirá como a única fonte de verdade para todas as operações da Frota.

### 2. Diretrizes Técnicas (Requisitos de Arquitetura)

O SOGF deve ser construído para durar, resistindo a mudanças tecnológicas e complexidade crescente. Para isso, a arquitetura é **não-negociável**.

1.  **Clean Architecture (Arquitetura Limpa):** O código deve ser separado em camadas distintas (Domínio, Aplicação, Infraestrutura). A regra de dependência é clara: camadas externas dependem de camadas internas. O Domínio não depende de ninguém.
2.  **Domain-Driven Design (DDD):** O código deve refletir a linguagem e as regras de negócio da Frota (ex: Naves, Missões, Facções). Você deve modelar Agregados, Entidades e **Value Objects** (para encapsular regras como Patentes, Status, etc.).
3.  **Princípios SOLID:** Seu código deve ser um exemplo de boas práticas, demonstrando os cinco princípios SOLID para garantir manutenibilidade e escalabilidade.

### 3. Requisitos Não Funcionais (Especificações Técnicas)

* **API RESTful:** Uso correto e semântico dos verbos HTTP (GET, POST, PUT/PATCH, DELETE) e códigos de status.
* **Autenticação (JWT):** O sistema deve ter autenticação via JSON Web Token.
* **Rotas Protegidas:** Todas as rotas (exceto login) devem ser protegidas e acessíveis apenas por pessoal autenticado.
* **CRUD Completo:** Todos os módulos de gerenciamento devem implementar operações de Criar, Ler, Atualizar e Deletar.
* **Tratamento de Erros:** A API deve retornar mensagens de erro claras e códigos de status apropriados.
* **Paginação, Filtros e Buscas:** Os pontos de listagem (ex: Naves, Combates) devem suportar paginação e filtros para evitar sobrecarga de dados.

### 4. O Contrato da API (Data Transfer Objects - DTOs)

Todos os dados que entram ou saem da API **devem** usar DTOs, que residem na **Camada de Aplicação**. Eles são o contrato explícito da sua API e protegem seu domínio.

* **DTOs de Entrada (Request):** Usados para criar ou atualizar recursos. Devem conter validações (ex: `IsNotEmpty()`, `IsString()`).
    * *Exemplo: `CreateNaveRequest` pode ter `nome: string`, `classe: string`, `capacidadeTripulacao: number`.*
* **DTOs de Saída (Response):** Usados para expor dados ao cliente. Eles garantem que dados sensíveis (como `senhaHash` de um usuário) nunca sejam expostos.
    * *Exemplo: `NaveResponse` pode ter `id: string`, `nome: string`, `classe: string`, `status: string`.*

O **Caso de Uso** (Camada de Aplicação) é responsável por **traduzir** DTOs em Entidades/Value Objects (na entrada) e Entidades/Value Objects em DTOs (na saída).

### 5. Módulos Operacionais (Requisitos Funcionais)

O SOGF é dividido nos seguintes módulos de domínio:

#### Módulo 1: Naves e Hangar (Ativos)
* **Necessidade:** Rastrear cada nave da frota.
* **Funções:** CRUD completo para Naves.
* **Dados Chave:** `Nome/Designação`, `Classe` (ex: "Classe Constitution"), `Capacidade de Tripulação`, `Status Operacional` (ex: "Pronta", "Em Reparo").

#### Módulo 2: Tripulação e Cadetes (Pessoal)
* **Necessidade:** Gerenciar o registro de todo o pessoal da Frota.
* **Funções:** CRUD completo para Tripulantes.
* **Dados Chave:** `Nome`, `Patente` (ex: "Capitão", "Cadete"), `Especialidade` (ex: "Tática", "Engenharia").

#### Módulo 3: Gerenciamento de Inteligência (Facções)
* **Necessidade:** Manter um banco de dados centralizado de todas as facções conhecidas.
* **Funções:** CRUD completo para Facções.
* **Dados Chave:** `NomeOficial` (único), `StatusDiplomatico` (ex: "Hostil", "Neutra"), `NivelAmeaca`.

#### Módulo 4: Missões e Briefing (Operações)
* **Necessidade:** Definir e rastrear os objetivos da Frota.
* **Funções:** CRUD completo para Missões.
* **Dados Chave:** `Objetivo`, `SetorGalactico`, `StatusdaMissao` (ex: "Planejada", "Em Andamento").

#### Módulo 5: Combate e Histórico (Diário de Bordo)
* **Necessidade:** Registrar todos os engajamentos táticos para análise futura.
* **Funções:** Registrar (Criar) e Consultar (Ler) Relatórios de Combate.
* **Dados Chave:** `Data`, `Resultado` (ex: "Vitória Tática"), `DescricaoTatica`.

#### Módulo 6: Pilotos e Perfis (Desempenho)
* **Necessidade:** Manter um histórico de serviço detalhado para o pessoal de voo.
* **Funções:** Consultar Perfil e Histórico de Combate de um piloto.
* **Dados Chave:** `Nome`, `Patente`, `HistoricoDeCombate` (lista de participações).

#### Módulo 7: Controle de Acesso (Segurança)
* **Necessidade:** Garantir que apenas pessoal autorizado acesse o SOGF.
* **Funções:** Rota de `login` (autenticação).
* **Dados Chave:** Credenciais de usuário (associadas a um Tripulante).

### 6. Regras de Relacionamento (A Lógica da Frota)

A principal complexidade do SOGF está em como os módulos se conectam. O sistema deve **garantir** as seguintes regras de negócio:

1.  **Nave <-> Missão:**
    * Uma `Missão` "Em Andamento" **deve** estar associada a uma `Nave`.
    * O sistema **deve impedir** que uma `Nave` "Em Reparo" seja alocada a uma nova `Missão`.
    * O sistema **deve impedir** que uma `Nave` seja alocada a duas missões ativas simultaneamente.

2.  **Missão <-> Tripulação:**
    * Uma `Missão` **deve** ter uma lista de `Tripulantes` associados (a equipe designada).

3.  **Combate <-> Facção:**
    * Um `Relatório de Combate` **deve** estar associado a uma `Facção` pré-existente no módulo de Inteligência. O sistema não deve permitir o registro de texto livre para o inimigo.

4.  **Combate <-> Naves:**
    * Um `Relatório de Combate` **deve** listar quais `Naves` da frota participaram do engajamento.

5.  **Combate <-> Pilotos (O Evento de Domínio):**
    * Este é um relacionamento assíncrono.
    * Quando um `Relatório de Combate` é registrado, o sistema deve **automaticamente** atualizar o `Perfil do Piloto` (Módulo 6) com os detalhes dessa participação.
    * O módulo de Combate **não deve** ter conhecimento direto (dependência) do módulo de Pilotos. Ele deve apenas notificar o sistema que "um combate ocorreu".

### 7. A Jornada do Cadete (Capítulos de Entrega)

Seu progresso será avaliado em etapas, que representam sua jornada na Frota.

**🛰️ Capítulo 1: O Primeiro Salto (Estrutura e Setup)**
* **Objetivo:** Configurar a arquitetura e o primeiro módulo.
* **Entregáveis:**
    * Estrutura de pastas da Clean Architecture (Domínio, Aplicação, Infraestrutura).
    * Configuração do banco de dados/ORM.
    * **Módulo de Naves (CRUD completo)** implementado, com o uso correto de DTOs (Entrada/Saída) e Value Objects (Domínio).

**🛰️ Capítulo 2: Comunicações Criptografadas (Segurança)**
* **Objetivo:** Proteger o sistema.
* **Entregáveis:**
    * **Módulo de Autenticação** (Login) e geração de JWT.
    * **Middleware/Guard de autenticação** aplicado.
    * Todas as rotas do Capítulo 1 agora devem estar protegidas.

**🛰️ Capítulo 3: Alocação da Frota (Relacionamentos)**
* **Objetivo:** Gerenciar a alocação de ativos e pessoal.
* **Entregáveis:**
    * **Módulo de Tripulação (CRUD completo)**.
    * **Módulo de Missões (CRUD completo)**.
    * Implementação das regras de negócio e relacionamentos entre `Missão`, `Nave` e `Tripulação`.

**🛰️ Capítulo 4: Diário de Bordo e Inteligência (Domínio Complexo)**
* **Objetivo:** Implementar os módulos táticos avançados.
* **Entregáveis:**
    * **Módulo de Facções (CRUD completo)**.
    * **Módulo de Combate (Registro e Consulta)**, com o relacionamento obrigatório com `Faccao`.
    * **Módulo de Pilotos (Consulta)**.
    * Implementação do **Evento de Domínio** que liga `Combate` ao `Perfil do Piloto`.
    * Implementação de **Paginação e Filtros** nas rotas de listagem (ex: Listar Combates por Facção).

---

**Fim da Transmissão.**
Boa sorte, Cadete. O Comando espera ansiosamente pelo seu sucesso. Ah, use sua inteligência natural para construção desse desafio 😉

# Sistema Oficial de Gerenciamento de Frota (SOGF)

API REST desenvolvida em **.NET 9** seguindo o padrão de **Arquitetura Limpa (Clean Architecture)**.
O sistema permite o gerenciamento completo de missões, naves, tripulantes, pilotos, facções e relatórios de combate, com autenticação JWT e integração opcional com modelos de IA.

---

## 1. FrontEnd [Front End do Projeto](https://github.com/yancarvalho13/starship-command-center)


## 2. DTO

Camada responsável pela comunicação entre a API e o domínio.

### 2.1. Facção

```csharp
public record FaccaoRequest(string nome, StatusDiplomatico statusDiplomatico, NivelAmeaca nivelAmeaca);
public record FaccaoResponse(long id, string nome, StatusDiplomatico statusDiplomatico, NivelAmeaca nivelAmeaca);
```

---

### 2.2. Missão

```csharp
public record MissaoRequest(ObjetivoMissao objetivoMissao, SetorGalatico setorGalatico, long naveId, long pilotoId, List<long> tripulantesId);

public record MissaoResponse(long id, ObjetivoMissao objetivoMissao, SetorGalatico setorGalatico, StatusMissao statusMissao, long naveId, long pilotoId, List<MissaoTripulanteResponse> tripulantesId);

public record MissaoTripulanteResponse(long id);
```

---

### 2.3. Nave

```csharp
public record NaveRequest(string nome, TipoNave classe, long capacidadeTripulacao, StatusOperacional status, long faccaoId);

public record NaveResponse(long id, string nome, TipoNave classe, StatusOperacional status, long faccaoId);

public record GetAllNavesResponse(List<NaveResponse> naves);
```

---

### 2.4. Piloto

```csharp
public record PilotoRequest(string nome, Patente patente);
public record PilotoResponse(long id, string nome, Patente patente);
```

---

### 2.5. Relatório de Combate

```csharp
public record EngajamentoCombateResponse(long naveId, long pilotoId, long relatorioCombateId, ResultadoCombate resultadoCombate);

public record HistoricoCombateResponse(List<RelatorioCombateResponse> vitorias, List<RelatorioCombateResponse> derrotas);

public record RelatorioCombateResponse(long id, DateTime data, ResultadoCombate resultadoCombate, string descricaoTatica, long faccaoVencedoraId, List<EngajamentoCombateResponse> engajamentoCombate);
```

---

### 2.6. Tripulante

```csharp
public record TripulanteRequest(string nome, Patente patente, Especialidade especialidade);

public record TripulanteResponse(long TripulanteId, string Nome, Patente Patente, Especialidade Especialidade);
```

---

### 2.7. Usuário

```csharp
public record UserLoginRequest(string username, string password);
public record UserRequest(string username, string password, Role[] roles);
public record UserResponse(string username, List<Role> roles);
```

---

## 3. Controllers

### 3.1. Controlador Genérico

```csharp
public interface IGenericController<TEntity, TRequest, TResponse>
{
    Task<IActionResult> Create(TRequest request);
    Task<IActionResult> GetAll();
    Task<IActionResult> GetById(long id);
    Task<IActionResult> Update(TRequest request, long id);
    Task<IActionResult> DeleteById(long id);
    Task<IActionResult> GetAllByPage(int page, int pageSize);
}
```

---

### 3.2. Controladores Específicos

**Piloto:**

```csharp
Task<IActionResult> ResumoPiloto(long id);
```

**Nave:**

```csharp
Task<IActionResult> ResumoNave(long id);
```

**Missão:**

```csharp
Task<IActionResult> IniciarMissao(MissaoRequest request);
Task<IActionResult> BuscarMissoes();
Task<IActionResult> BuscarPorId(long id);
```

**Autenticação:**

```csharp
[HttpPost("/login")]
Task<IActionResult> Login(UserLoginRequest request);

[HttpPost("/register")]
Task<IActionResult> Register(UserRequest request);
```

---

## 4. Result Pattern

Padrão de retorno utilizado em todos os serviços da aplicação, encapsulando sucesso, falhas e validações.

```csharp
public record Result
{
    public bool isSuccess { get; }
    public Error? Error { get; }
    public bool? IsValidation { get; }
    public List<ValidationFailureResponse>? ValidationFailures { get; }
}
```

**Implementação genérica:**

```csharp
public record Result<T> : Result
{
    public T? Value { get; }
}
```

**Tipos de retorno:**

* `Result.Success()`
* `Result.Failure(Error error)`
* `Result.ValidationFailure(List<ValidationFailureResponse>)`

---

## 5. Paginação

A estrutura `PagedResult<T>` padroniza respostas paginadas:

```csharp
public class PagedResult<T>
{
    public IEnumerable<T> Items { get; set; }
    public bool isSucces { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }
    public long TotalRecords { get; set; }
    public long TotalPages { get; set; }
}
```

---

## 6. Autenticação e Segurança

O sistema utiliza **JWT (JSON Web Token)** para autenticação.
O token é gerado via `ITokenProvider.GenerateToken(User user)` e utilizado para proteger os endpoints da API.

---

## 7. Status de Domínio

Enums usados para representar estados e classificações:
* `Especialidade`: Batalha, Engenharia, Medicina, Estrategista
* `ObjetivoMissao`: Infiltracao, Exploracao, Ataque
* `StatusOperacional`: Pronta, EmReparo
* `Patente`: Cadete, Tenente, Capitao
* `TipoNave`: CruzadorDeBatalha, Utilitario, Patrulha
* `StatusDiplomatico`: Neutro, Agressivo, Pacifico
* `NivelAmeaca`: Baixo, Medio, Alto
* `StatusMissao`: Planejada, EmAndamento, Concluída
* `ResultadoCombate`: Vitória, Derrota

---

## 8. Execução e Testes
**Docker:**
Suba o banco sqlServer aqui:

Senha : Senha123.

Usuario: sa

```
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=Senha123." \               
-p 1433:1433 --name sql2 --hostname sql2 \
-d \
mcr.microsoft.com/mssql/server:2025-latest
```
Armazene a chave da sua Api Gemini no User Secrets do projeto SOGF.API

"GOOGLE_API_KEY": "suachave",

"Jwt:Secret": "seusegredosupersecreto"

**Swagger UI:**
Acesse a documentação interativa da API:
[http://localhost:5165/index.html](http://localhost:5165/index.html)

**Comando de execução:**

```bash
dotnet run --project Solution.Api
```


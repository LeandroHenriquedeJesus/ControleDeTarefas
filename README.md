# ControleDeTarefas 📝

Aplicação console em C# para gerenciar tarefas com cadastro, listagem, atualização de status e filtros.

## 🚀 Funcionalidades

- ✅ Cadastrar nova tarefa (título, descrição, data e status)
- 📋 Listar todas as tarefas cadastradas
- 🔄 Marcar tarefas como concluídas
- 🔍 Filtrar tarefas por:
  - Status (Pendente, Em Andamento, Concluída)

---

## 🛠️ Tecnologias

- **Linguagem:** C#
- **Framework:** .NET 6
- **Tipo de aplicação:** Console
- **Organização:** Separação por camadas (Models, Services)
- **Boas práticas:** Tratamento de exceções e uso de enums

---

## 🧑‍💻 Estrutura de Pastas

ControleDeTarefas/
- │
- ├── Models/            # Modelos de dados (Tarefa e enum StatusTarefa)
- ├── Services/          # Lógica de negócio (TarefaService)
- ├── Program.cs         # Interface via terminal
- └── ControleDeTarefas.csproj

---

## 💻 Como executar

### Pré-requisitos

- [.NET 6 SDK](https://dotnet.microsoft.com/en-us/download) instalado

### Passos

```bash
# Clone o repositório
git clone https://github.com/LeandroHenriquedeJesus/ControleDeTarefas.git
cd ControleDeTarefas

# Execute a aplicação
dotnet run

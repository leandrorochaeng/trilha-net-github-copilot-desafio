# Validador de Bandeira de Cartão de Crédito

## 📋 Descrição

Sistema em C# que valida e identifica a bandeira de um cartão de crédito através do seu número. Implementa o padrão de identificação BIN (Bank Identification Number) para reconhecer as principais bandeiras internacionais e brasileiras.

## 🎯 Funcionalidades

- Identifica automaticamente a bandeira do cartão
- Valida o comprimento esperado do número
- Interface interativa em linha de comando

## 💳 Bandeiras Suportadas

| Bandeira | Prefixo | Comprimento | Padrão |
|----------|---------|------------|--------|
| **Visa** | 4 | 13 ou 16 | Começa com 4 |
| **MasterCard** | 51-55, 2221-2720 | 16 | Começa com 51-55 ou 2221-2720 |
| **American Express** | 34, 37 | 15 | Começa com 34 ou 37 |
| **Diners Club** | 36, 38, 300-305 | 14 | Começa com 36, 38 ou 300-305 |
| **Discover** | 6011, 622126-622925, 644-649, 65 | 16 | Múltiplos prefixos |
| **EnRoute** | 2014, 2149 | 15 | Começa com 2014 ou 2149 |
| **JCB** | 3528-3589 | 16 | Começa com 3528-3589 |
| **Voyager** | 8699 | 15 | Começa com 8699 |
| **HiperCard** | 6062 | 16 | Começa com 6062 |
| **Aura** | 50 | 16 | Começa com 50 |

## 🚀 Como Usar

### Compilar e Executar

```bash
dotnet run
```

### Exemplos de Uso

**Visa:**
```
> 4111111111111111
Bandeira: Visa
```

**MasterCard:**
```
> 5555555555554444
Bandeira: MasterCard
```

**American Express:**
```
> 378282246310005
Bandeira: American Express
```

**HiperCard (Brasileiro):**
```
> 6062826564883708
Bandeira: HiperCard
```

## 📝 Notas

- O sistema remove automaticamente espaços e caracteres não-numéricos do número digitado
- Números desconhecidos ou com formato inválido são identificados como "Desconhecida"
- Para sair do programa, digite "sair"
- A validação se baseia em regras de BIN (Bank Identification Number), que definem:
  - O prefixo inicial do número (primeiro(s) dígito(s))
  - O comprimento total esperado para a bandeira
  - Ranges de valores para identificação precisa

---


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GITHUB_COPILOT.Models
{
    public class CartaoCredito
    {
        public string Numero { get; set; }
        public string Bandeira { get; set; }

        public CartaoCredito(string numero)
        {
            Numero = numero?.Trim() ?? "";
            Bandeira = ValidarBandeira();
        }

        /// <summary>
        /// Valida a bandeira do cartão de crédito com base no número
        /// </summary>
        /// <returns>Nome da bandeira ou "Desconhecida" se não encontrada</returns>
        private string ValidarBandeira()
        {
            // Remove espaços e caracteres não numéricos
            string numLimpo = new string(Numero.Where(char.IsDigit).ToArray());

            if (string.IsNullOrEmpty(numLimpo))
                return "Desconhecida";

            // Verifica cada bandeira seguindo os padrões de BIN (Bank Identification Number)
            if (ValidarVisa(numLimpo))
                return "Visa";
            
            if (ValidarMasterCard(numLimpo))
                return "MasterCard";
            
            if (ValidarAmex(numLimpo))
                return "American Express";
            
            if (ValidarDinersClub(numLimpo))
                return "Diners Club";
            
            if (ValidarDiscover(numLimpo))
                return "Discover";
            
            if (ValidarEnRoute(numLimpo))
                return "EnRoute";
            
            if (ValidarJCB(numLimpo))
                return "JCB";
            
            if (ValidarVoyager(numLimpo))
                return "Voyager";
            
            if (ValidarHiperCard(numLimpo))
                return "HiperCard";
            
            if (ValidarAura(numLimpo))
                return "Aura";

            return "Desconhecida";
        }

        private bool ValidarVisa(string numero)
        {
            // Começa com 4 e tem 13 ou 16 dígitos
            return numero.StartsWith("4") && (numero.Length == 13 || numero.Length == 16);
        }

        private bool ValidarMasterCard(string numero)
        {
            // Começa com 51-55 (padrão antigo) ou 2221-2720 (novo padrão), tem 16 dígitos
            if (numero.Length != 16)
                return false;

            if (numero.StartsWith("5") && numero[1] >= '1' && numero[1] <= '5')
                return true;

            if (numero.Length >= 4)
            {
                if (int.TryParse(numero.Substring(0, 4), out int prefixo))
                {
                    return prefixo >= 2221 && prefixo <= 2720;
                }
            }

            return false;
        }

        private bool ValidarAmex(string numero)
        {
            // Começa com 34 ou 37, tem 15 dígitos
            return numero.Length == 15 && (numero.StartsWith("34") || numero.StartsWith("37"));
        }

        private bool ValidarDinersClub(string numero)
        {
            // Começa com 36, 38, ou 300-305, tem 14 dígitos
            if (numero.Length != 14)
                return false;

            if (numero.StartsWith("36") || numero.StartsWith("38"))
                return true;

            if (numero.Length >= 3)
            {
                if (int.TryParse(numero.Substring(0, 3), out int prefixo))
                {
                    return prefixo >= 300 && prefixo <= 305;
                }
            }

            return false;
        }

        private bool ValidarDiscover(string numero)
        {
            // Começa com 6011, 622126-622925, 644-649, ou 65, tem 16 dígitos
            if (numero.Length != 16)
                return false;

            if (numero.StartsWith("6011") || numero.StartsWith("65"))
                return true;

            if (numero.StartsWith("644") || numero.StartsWith("645") || 
                numero.StartsWith("646") || numero.StartsWith("647") || 
                numero.StartsWith("648") || numero.StartsWith("649"))
                return true;

            if (numero.Length >= 6)
            {
                if (int.TryParse(numero.Substring(0, 6), out int prefixo))
                {
                    return prefixo >= 622126 && prefixo <= 622925;
                }
            }

            return false;
        }

        private bool ValidarEnRoute(string numero)
        {
            // Começa com 2014 ou 2149, tem 15 dígitos
            return numero.Length == 15 && (numero.StartsWith("2014") || numero.StartsWith("2149"));
        }

        private bool ValidarJCB(string numero)
        {
            // Começa com 3528-3589, tem 16 dígitos
            if (numero.Length != 16)
                return false;

            if (numero.Length >= 4)
            {
                if (int.TryParse(numero.Substring(0, 4), out int prefixo))
                {
                    return prefixo >= 3528 && prefixo <= 3589;
                }
            }

            return false;
        }

        private bool ValidarVoyager(string numero)
        {
            // Começa com 8699, tem 15 dígitos
            return numero.Length == 15 && numero.StartsWith("8699");
        }

        private bool ValidarHiperCard(string numero)
        {
            // Começa com 6062, tem 16 dígitos
            return numero.Length == 16 && numero.StartsWith("6062");
        }

        private bool ValidarAura(string numero)
        {
            // Começa com 50, tem 16 dígitos
            return numero.Length == 16 && numero.StartsWith("50");
        }
    }
}
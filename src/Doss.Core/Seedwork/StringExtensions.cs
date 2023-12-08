using Doss.Core.Domain.Enums;
using System.Text.RegularExpressions;

namespace System
{
    public static class StringExtensions
    {
        static readonly int[] Multiplicador1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        static readonly int[] Multiplicador2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

        public static bool IsNotNullOrEmpty(this string value)
            => !string.IsNullOrEmpty(value);

        public static bool IsNullOrEmpty(this string value)
            => string.IsNullOrEmpty(value);

        public static bool IsValidCpf(this string value)
        {
            if (value == null) return false;

            var posicao = 0;
            var totalDigito1 = 0;
            var totalDigito2 = 0;
            var dv1 = 0;
            var dv2 = 0;

            bool digitosIdenticos = true;
            var ultimoDigito = -1;

            foreach (var c in value)
            {
                if (char.IsDigit(c))
                {
                    var digito = c - '0';
                    if (posicao != 0 && ultimoDigito != digito)
                    {
                        digitosIdenticos = false;
                    }

                    ultimoDigito = digito;
                    if (posicao < 9)
                    {
                        totalDigito1 += digito * (10 - posicao);
                        totalDigito2 += digito * (11 - posicao);
                    }
                    else if (posicao == 9)
                    {
                        dv1 = digito;
                    }
                    else if (posicao == 10)
                    {
                        dv2 = digito;
                    }

                    posicao++;
                }
            }

            if (posicao > 11)
            {
                return false;
            }

            if (digitosIdenticos)
            {
                return false;
            }

            var digito1 = totalDigito1 % 11;
            digito1 = digito1 < 2
                ? 0
                : 11 - digito1;

            if (dv1 != digito1)
            {
                return false;
            }

            totalDigito2 += digito1 * 2;
            var digito2 = totalDigito2 % 11;
            digito2 = digito2 < 2
                ? 0
                : 11 - digito2;

            return dv2 == digito2;
        }

        public static bool IsValidCnpj(this string value)
        {
            if (value == null)
                return false;

            var digitosIdenticos = true;
            var ultimoDigito = -1;
            var posicao = 0;
            var totalDigito1 = 0;
            var totalDigito2 = 0;

            foreach (var c in value)
            {
                if (char.IsDigit(c))
                {
                    var digito = c - '0';
                    if (posicao != 0 && ultimoDigito != digito)
                    {
                        digitosIdenticos = false;
                    }

                    ultimoDigito = digito;
                    if (posicao < 12)
                    {
                        totalDigito1 += digito * Multiplicador1[posicao];
                        totalDigito2 += digito * Multiplicador2[posicao];
                    }
                    else if (posicao == 12)
                    {
                        var dv1 = (totalDigito1 % 11);
                        dv1 = dv1 < 2
                            ? 0
                            : 11 - dv1;

                        if (digito != dv1)
                            return false;

                        totalDigito2 += dv1 * Multiplicador2[12];
                    }
                    else if (posicao == 13)
                    {
                        var dv2 = (totalDigito2 % 11);

                        dv2 = dv2 < 2
                            ? 0
                            : 11 - dv2;

                        if (digito != dv2)
                            return false;
                    }

                    posicao++;
                }
            }

            return (posicao == 14) && !digitosIdenticos;
        }

        public static bool IsValidDocument(this string value, TypeDocument typeDocument)
        {
            if (typeDocument == TypeDocument.Cnpj)
                return IsValidCnpj(value);

            return IsValidCpf(value);
        }

        public static string RemoveSpecialCharacter(this string value)
            => Regex.Replace(value, "[^0-9a-zA-Z]", "");

        public static string OnlyNumbers(this string value)
            => string.Join("", new Regex(@"\d+").Matches(value));
    }
}

using System;

class Program {
    static void Main(string[] args) {
        Console.Write("Digite um número: ");
        string numeroString = Console.ReadLine();

        if (decimal.TryParse(numeroString, out decimal numeroDecimal)) {
            Console.WriteLine(NumeroPorExtenso(numeroDecimal));
        }
        else {
            Console.WriteLine("Número inválido.");
        }
    }

    static string NumeroPorExtenso(decimal numero) {
        string[] unidades = {"zero", "um", "dois", "três", "quatro", "cinco", "seis", "sete", "oito", "nove"};
        string[] dezenas = {"", "dez", "vinte", "trinta", "quarenta", "cinquenta", "sessenta", "setenta", "oitenta", "noventa"};
        string[] centenas = {"", "cem", "duzentos", "trezentos", "quatrocentos", "quinhentos", "seiscentos", "setecentos", "oitocentos", "novecentos"};

        string[] partes = numero.ToString("F2").Split(',');
        int inteiro = int.Parse(partes[0]);
        int decimalParte = int.Parse(partes[1]);

        string porExtenso = "";

        if (inteiro == 0) {
            porExtenso = unidades[0];
        }
        else if (inteiro == 100) {
            porExtenso = centenas[1];
        }
        else if (inteiro < 100) {
            if (inteiro < 10) {
                porExtenso = unidades[inteiro];
            }
            else if (inteiro == 10) {
                porExtenso = dezenas[1];
            }
            else if (inteiro < 20) {
                porExtenso = unidades[inteiro % 10] + " " + dezenas[1];
            }
            else {
                porExtenso = dezenas[inteiro / 10];
                if (inteiro % 10 != 0) {
                    porExtenso += " e " + unidades[inteiro % 10];
                }
            }
        }
        else if (inteiro < 1000) {
            porExtenso = centenas[inteiro / 100];
            if (inteiro % 100 != 0) {
                porExtenso += " e " + NumeroPorExtenso(inteiro % 100);
            }
        }

        if (decimalParte > 0) {
            if (porExtenso != "") {
                porExtenso += " e ";
            }
            if (decimalParte < 10) {
                porExtenso += unidades[decimalParte];
            }
            else {
                porExtenso += dezenas[decimalParte / 10];
                if (decimalParte % 10 != 0) {
                    porExtenso += " e " + unidades[decimalParte % 10];
                }
            }
            porExtenso += " centavos";
        }

        return porExtenso;
    }
}

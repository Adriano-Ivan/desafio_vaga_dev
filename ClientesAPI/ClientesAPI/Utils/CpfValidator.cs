namespace ClientesAPI.Utils
{
    public class CpfValidator
    {
        public bool IsValid(string cpf)
        {
            // Remove caracteres não numéricos do CPF.
            cpf = new string(cpf.Where(char.IsDigit).ToArray());

            // Verifica se o CPF possui 11 dígitos.
            if (cpf.Length != 11)
            {
                return false;
            }

            // Verifica se todos os dígitos são iguais.
            if (cpf.Distinct().Count() == 1)
            {
                return false;
            }

            // Calcula o primeiro dígito verificador.
            int sum = 0;
            for (int i = 0; i < 9; i++)
            {
                sum += int.Parse(cpf[i].ToString()) * (10 - i);
            }
            int firstDigit = 11 - (sum % 11);

            if (firstDigit >= 10)
            {
                firstDigit = 0;
            }

            // Calcula o segundo dígito verificador.
            sum = 0;
            for (int i = 0; i < 10; i++)
            {
                sum += int.Parse(cpf[i].ToString()) * (11 - i);
            }
            int secondDigit = 11 - (sum % 11);

            if (secondDigit >= 10)
            {
                secondDigit = 0;
            }

            // Verifica se os dígitos verificadores são iguais aos dígitos originais.
            if (cpf[9] - '0' == firstDigit && cpf[10] - '0' == secondDigit)
            {
                return true;
            }

            return false;
        }
    }
}

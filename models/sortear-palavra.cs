namespace sortear_palavra.model
{
    public class Jogo
    {
        private static readonly string[] palavras = ["casa", "carro", "amor", "vida", "paz", "alegria", "felicidade", "amizade", "família", "esperança",
    "liberdade", "natureza", "beleza", "confiança", "criatividade", "força", "sabedoria", "verdade", "coragem", "compaixão"];

        public static void IniciarJogo()
        {
            string palavraEscolhida = SortearPalavra();
            string[] palavraOculta = new string[palavraEscolhida.Length]; /* Inicializa a array com o mesmo tamnho da palavra escolhida */

            for (int i = 0; i < palavraEscolhida.Length; i++)
            {
                palavraOculta[i] = "*";
            }

            iniciarTentativas(palavraEscolhida, palavraOculta);
        }
        private static void iniciarTentativas(string palavraSorteada, string[] palavraOculta)
        {
            string palpite = "";
            int tentativasUsadas = 0;
            char[] letrasDaPalavraSorteada = palavraSorteada.ToCharArray(0, palavraSorteada.Length);

            while (palpite != "sair")
            {   
                Console.Clear();
                Console.WriteLine("DESCUBRA A PALAVRA!\n\nUma palavra misteriosa foi escolhida e você precisa descobrir qual é!");
                Console.WriteLine($"\nNúmero de letras: {palavraSorteada.Length}");

                int maxTentativas = palavraSorteada.Length + (palavraSorteada.Length / 2);

                Console.WriteLine($"Tentativas restantes: {maxTentativas - tentativasUsadas}");
                Console.WriteLine($"\nA palavra misteriosa é: {String.Join("", palavraOculta)}.\n\nTente adivinhar uma das letras: ");
        
                palpite = Console.ReadLine().ToLower();

                if ((palpite.Length > 1 && palpite != "sair" && palpite != palavraSorteada) || palpite == "")
                {
                    Console.WriteLine("Ops! Seu palpite deve ter apenas uma letra, ou ser igaul a palavra misteriosa.");
                    Console.Clear();
                    continue;
                }    

                if (palavraSorteada.Contains(palpite) && palpite != palavraSorteada)
                {

                    for (int i = 0; i < letrasDaPalavraSorteada.Length; i++)
                    {   
                        if (letrasDaPalavraSorteada[i].ToString() == palpite)
                        {
                            palavraOculta[i] = palpite;
                        }
                    }
                }
                
                if (String.Concat(palavraOculta) == palavraSorteada || String.Concat(palavraOculta) == palpite || palpite == palavraSorteada)
                {
                    Console.WriteLine("\nParabéns! Você acertou a palavra misteriosa!\n\nAperte 'Enter' para reiniciar ou 'escreva 'sair' para encerrar o jogo.'");
                    
                    palpite = Console.ReadLine().ToLower();

                    if (palpite != "sair")
                    {   
                        break;
                    }
                }

                tentativasUsadas++;
            }
            IniciarJogo();
        }
        private static string SortearPalavra()
        {
            Random random = new();
            return palavras[random.Next(palavras.Length - 1)];
        }
    }
}
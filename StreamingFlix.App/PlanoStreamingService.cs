using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StreamingFlix.App
{
    public class PlanoStreamingService
    {
        private int quantidadeTelasBasico = 1;
        private int quantidadeTelasPadrao = 2;
        private int quantidadeTelasPremium = 4;
        public string ObterClassificacaoPorQualidade(int telasSimultaneas)
        {
            if (telasSimultaneas == quantidadeTelasBasico)
            { return "BÁSICO"; }
            else if (telasSimultaneas == quantidadeTelasPadrao)
            { return "PADRÃO"; }
            else if (telasSimultaneas <= quantidadeTelasPremium)
            { return "PREMIUN"; }
            else 
            { return "QUANTIDADE INVALIDA DE TELAS"; }
        }
        public int CalcularMensalidadeComDesconto(int valorBase, int mesesContratados)
        {
            if (mesesContratados >= 12)
            { return valorBase * 80 / 100; }

            if (mesesContratados >= 6)
            { return valorBase * 90 / 100; }

            return valorBase; 
        }
        public bool PodeAcessarConteudoAdulto(int idade, bool controleParentalAtivo)
        {
            return idade >= 18 && !controleParentalAtivo;
        }
    }
}
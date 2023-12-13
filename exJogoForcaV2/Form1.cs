using System.Windows.Forms;

namespace exJogoForcaV2
{
    public partial class Form1 : Form
    {
        //variaveis globais à classe
        string[] palavras; //array para o dicionário de palavras
        string palavra;
        char[] palEscondido; //array de caracteres para a palavra a adivinhar
        bool acertou;
        string grau = "facil";
        short nImg = 0; //para contar as imagens
        bool soundON = false;


        private Form1()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            BotaoStart.Visible = true;
            BotaoSom.Visible = false;
            groupBoxDificuldade.Visible = false;
            groupBoxTeclado.Visible = false;
            BotaoDificuldade.Visible = true;
            acertou = false;
            grau = "medio";
            nImg = 0;
            ApresentarImagem(nImg);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            BotaoStart.Visible = true;
            button1.Visible = false;
            groupBoxDificuldade.Visible = false;
            groupBoxTeclado.Visible = false;
            BotaoDificuldade.Visible = true;
            acertou = false;
            nImg = 0;
            ApresentarImagem(nImg);
        }

        private void ApresentarImagem(short n)
        {
            try
            {
                if (n == 0)
                    pictureBoxForca.Image = Properties.Resources.forca0;
                else if (n == 1)
                    pictureBoxForca.Image = Properties.Resources.forca1;
                else if (n == 2)
                    pictureBoxForca.Image = Properties.Resources.forca2;
                else if (n == 3)
                    pictureBoxForca.Image = Properties.Resources.forca3;
                else if (n == 4)
                    pictureBoxForca.Image = Properties.Resources.forca4;
                else if (n == 5)
                    pictureBoxForca.Image = Properties.Resources.forca5;
                else if (n == 6)
                    pictureBoxForca.Image = Properties.Resources.forca6;
                else if (n == 7)
                    pictureBoxForca.Image = Properties.Resources.forca7;
                else if (n == 8)
                    pictureBoxForca.Image = Properties.Resources.forca8;
                else if (n == 9)
                    pictureBoxForca.Image = Properties.Resources.forcaMorto;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro na apresentação da imagem: " + ex.Message);
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            IniciarJogo();
            labelLetras.Visible = true;
            IniciarDicionario();
            BotaoDificuldade.Visible = true;
            BotaoStart.Visible = true;
            pictureBox1.Image = Properties.Resources.forca;
            pictureBoxForca.Visible = true;
            MostrarLetras();
            string word = SelecionarPalavra();
            ApresentarPalavra(word);
            SomInicial();
        }

        private void IniciarDicionario()
        {
            palavras = new string[30];
            try
            {
                if (grau == "facil")
                {
                    palavras[0] = "Banana";
                    palavras[1] = "Melão";
                    palavras[2] = "Maça";
                    palavras[3] = "Ananás";
                    palavras[4] = "Papaia";
                    palavras[5] = "Mamão";
                    palavras[6] = "Cereja";
                    palavras[7] = "Laranja";
                    palavras[8] = "Tangerina";
                    palavras[9] = "Tângera";
                    palavras[10] = "Pera";
                    palavras[11] = "Kiwi";
                    palavras[12] = "Pêssego";
                    palavras[13] = "Ameixa";
                    palavras[14] = "Abacate";
                    palavras[15] = "Melância";
                    palavras[16] = "Damasco";
                    palavras[17] = "Uvas";
                    palavras[18] = "Morango";
                    palavras[19] = "Limão";
                    palavras[20] = "Manga";
                    palavras[21] = "Nêspera";
                    palavras[22] = "Marmelo";
                    palavras[23] = "Framboesa";
                    palavras[24] = "Amora";
                    palavras[25] = "Mirtilio";
                    palavras[26] = "Romã";
                    palavras[27] = "Tâmara";
                    palavras[28] = "Figo";
                    palavras[29] = "Lima";
                }
                else if (grau == "medio")
                {
                    palavras[0] = "Botswana";
                    palavras[1] = "Angola";
                    palavras[2] = "Libéria";
                    palavras[3] = "Tanzânia";
                    palavras[4] = "Serra Leoa";
                    palavras[5] = "Zimbabwe";
                    palavras[6] = "Moçambique";
                    palavras[7] = "Afeganistão";
                    palavras[8] = "Zâmbia";
                    palavras[9] = "Malawi";
                    palavras[10] = "Namíbia";
                    palavras[11] = "Nigéria";
                    palavras[12] = "Somália";
                    palavras[13] = "Guiné Bissau";
                    palavras[14] = "Ruanda";
                    palavras[15] = "Etiópia";
                    palavras[16] = "Rússia";
                    palavras[17] = "Ucrânia";
                    palavras[18] = "Bulgária";
                    palavras[19] = "Bielorrúsia";
                    palavras[20] = "Quénia";
                    palavras[21] = "Letônia";
                    palavras[22] = "Camarões";
                    palavras[23] = "Burundi";
                    palavras[24] = "Estónia";
                    palavras[25] = "Gâmbia";
                    palavras[26] = "Moldávia";
                    palavras[27] = "Eslovénia";
                    palavras[28] = "Gabão";
                    palavras[29] = "Uganda";
                }
                else if (grau == "dificil")
                {
                    palavras[0] = "Butão";
                    palavras[1] = "Guernsey";
                    palavras[2] = "Mianmar";
                    palavras[3] = "Azerbaijão";
                    palavras[4] = "Eritreia";
                    palavras[5] = "Cazaquistão";
                    palavras[6] = "Gana";
                    palavras[7] = "Togo";
                    palavras[8] = "Senegal";
                    palavras[9] = "Jersey";
                    palavras[10] = "Belize";
                    palavras[11] = "Comboja";
                    palavras[12] = "Bahamas";
                    palavras[13] = "Turquemenistão";
                    palavras[14] = "Lêmen";
                    palavras[15] = "Kiribati";
                    palavras[16] = "Bangladesh";
                    palavras[17] = "Tajiquistão";
                    palavras[18] = "Uzbequistão";
                    palavras[19] = "Vanuatu";
                    palavras[20] = "Mayotte";
                    palavras[21] = "Suriname";
                    palavras[22] = "Papua nova Guiné";
                    palavras[23] = "Liechtenstein";
                    palavras[24] = "Tuvalu";
                    palavras[25] = "Quirguistão";
                    palavras[26] = "Palau";
                    palavras[27] = "Nauru";
                    palavras[28] = "Samoa";
                    palavras[29] = "Seicheles";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro no carregamento da dicionario: " + ex.Message);
            }
        }

        private void MostrarLetras()
        {
            groupBoxTeclado.Visible = true;
            foreach (Button b in groupBoxTeclado.Controls)
                b.Visible = true;
        }

        private string SelecionarPalavra()
        {
            Random rnd = new Random();
            int n = rnd.Next(30);
            return (palavras[n]);
        }

        private void ApresentarPalavra(string s)
        {
            int tam = s.Length;
            palEscondido = new char[tam];
            for (int i = 0; i < tam; i++)
                palEscondido[i] = '-';
            string sF = new string(palEscondido);
            labelLetras.Text = sF;
            palavra = s;
        }


        private void SomInicial()
        {
            Stream st = Properties.Resources.bensoundLlittleidea;
            System.Media.SoundPlayer sp = new System.Media.SoundPlayer(st);
            sp.PlayLooping();
            soundON = true;
        }




        private void VerificarLetra(char c)
        {
            char[] pal = palavra.ToCharArray();
            for (int i = 0; i < palavra.Length; i++)
            {
                if (pal[i] == c)
                {
                    acertou = true;
                    palEscondido[i] = c;
                }
            }
            string s = new string(palEscondido);
            labelLetras.Text = s;
        }

        private void AtualizarJogo()
        {
            if (acertou)
            {
                nImg++;
                ApresentarImagem(nImg);
                if (nImg == 9)
                    Perdeu();
            }
            VerificarSeGanhou();
        }
        private void Perdeu()
        {
            groupBoxDificuldade.Visible = false;
            pictureBoxForca.Visible = false;
            groupBoxTeclado.Visible = false;
            labelLetras.Visible = false;
            BotaoDificuldade.Visible = false;
            pictureBox1.Image = Properties.Resources.loser;
        }

        private void VerificarSeGanhou()
        {
            string s = new string(palEscondido);
            if (string.Compare(s, palavra) == 0)
                Ganhou();
        }

        private void Ganhou()
        {
            groupBoxDificuldade.Visible = false;
            pictureBoxForca.Visible = false;
            groupBoxTeclado.Visible = false;
            labelLetras.Visible = false;
            BotaoDificuldade.Visible = false;
            pictureBox1.Image = Properties.Resources.vencedor;
        }

        
        private void BotaoB_Click(object sender, EventArgs e)
        {
            BotaoB.Visible = false;
            acertou = false;
            VerificarLetra('B');
            VerificarLetra('b');
            AtualizarJogo();
        }

       
        

        
       
       
        private void BotaoI_Click(object sender, EventArgs e)
        {
            BotaoI.Visible = false;
            acertou = false;
            VerificarLetra('I');
            VerificarLetra('i');
            VerificarLetra('í');
            VerificarLetra('ì');
            VerificarLetra('î');
            AtualizarJogo();
        }
        private void BotaoJ_Click(object sender, EventArgs e)
        {
            BotaoJ.Visible = false;
            acertou = false;
            VerificarLetra('J');
            VerificarLetra('j');
            AtualizarJogo();
        }
        private void BotaoK_Click(object sender, EventArgs e)
        {
            BotaoK.Visible = false;
            acertou = false;
            VerificarLetra('K');
            VerificarLetra('k');
            AtualizarJogo();
        }
        private void BotaoL_Click(object sender, EventArgs e)
        {
            BotaoL.Visible = false;
            acertou = false;
            VerificarLetra('L');
            VerificarLetra('l');
            AtualizarJogo();
        }
        private void BotaoM_Click(object sender, EventArgs e)
        {
            BotaoM.Visible = false;
            acertou = false;
            VerificarLetra('M');
            VerificarLetra('m');
            AtualizarJogo();
        }
        private void BotaoN_Click(object sender, EventArgs e)
        {
            BotaoN.Visible = false;
            acertou = false;
            VerificarLetra('N');
            VerificarLetra('n');
            AtualizarJogo();
        }
        private void BotaoO_Click(object sender, EventArgs e)
        {
            BotaoO.Visible = false;
            acertou = false;
            VerificarLetra('O');
            VerificarLetra('o');
            VerificarLetra('ó');
            VerificarLetra('ò');
            VerificarLetra('ô');
            AtualizarJogo();
        }
        private void BotaoP_Click(object sender, EventArgs e)
        {
            BotaoP.Visible = false;
            acertou = false;
            VerificarLetra('P');
            VerificarLetra('p');
            AtualizarJogo();
        }
        private void BotaoQ_Click(object sender, EventArgs e)
        {
            BotaoQ.Visible = false;
            acertou = false;
            VerificarLetra('Q');
            VerificarLetra('Q');
            AtualizarJogo();
        }
        private void BotaoR_Click(object sender, EventArgs e)
        {
            BotaoR.Visible = false;
            acertou = false;
            VerificarLetra('R');
            VerificarLetra('r');
            AtualizarJogo();
        }
        private void BotaoS_Click(object sender, EventArgs e)
        {
            BotaoS.Visible = false;
            acertou = false;
            VerificarLetra('S');
            VerificarLetra('s');
            AtualizarJogo();
        }
        private void BotaoT_Click(object sender, EventArgs e)
        {
            BotaoT.Visible = false;
            acertou = false;
            VerificarLetra('T');
            VerificarLetra('t');
            AtualizarJogo();
        }
        private void BotaoU_Click(object sender, EventArgs e)
        {
            BotaoU.Visible = false;
            acertou = false;
            VerificarLetra('U');
            VerificarLetra('u');
            VerificarLetra('ú');
            VerificarLetra('ù');
            VerificarLetra('û');
            AtualizarJogo();
        }
        private void BotaoV_Click(object sender, EventArgs e)
        {
            BotaoV.Visible = false;
            acertou = false;
            VerificarLetra('V');
            VerificarLetra('v');
            AtualizarJogo();
        }
        private void BotaoW_Click(object sender, EventArgs e)
        {
            BotaoW.Visible = false;
            acertou = false;
            VerificarLetra('W');
            VerificarLetra('w');
            AtualizarJogo();
        }
        private void BotaoX_Click(object sender, EventArgs e)
        {
            BotaoX.Visible = false;
            acertou = false;
            VerificarLetra('X');
            VerificarLetra('x');
            AtualizarJogo();
        }
        private void BotaoY_Click(object sender, EventArgs e)
        {
            BotaoY.Visible = false;
            acertou = false;
            VerificarLetra('Y');
            VerificarLetra('y');
            AtualizarJogo();
        }
        private void BotaoZ_Click(object sender, EventArgs e)
        {
            BotaoZ.Visible = false;
            acertou = false;
            VerificarLetra('Z');
            VerificarLetra('z');
            AtualizarJogo();
        }



        private void buttonA_Click(object sender, System.EventArgs e)
        {
            buttonA.Visible = false;
            acertou = false;
            VerificarLetra('A');
            VerificarLetra('a');
            VerificarLetra('á');
            VerificarLetra('à');
            VerificarLetra('ã');
            AtualizarJogo();
        }

        private void buttonB_Click(object sender, System.EventArgs e)
        {
            buttonB.Visible = false;
            acertou = false;
            VerificarLetra('B');
            VerificarLetra('b');
            AtualizarJogo();
        }

        private void buttonC_Click(object sender, System.EventArgs e)
        {
            buttonC.Visible = false;
            acertou = false;
            VerificarLetra('C');
            VerificarLetra('c');
            VerificarLetra('ç');
            AtualizarJogo();
        }

        private void buttonD_Click(object sender, System.EventArgs e)
        {
            buttonD.Visible = false;
            acertou = false;
            VerificarLetra('D');
            VerificarLetra('d');
            AtualizarJogo();
        }

        private void buttonE_Click(object sender, System.EventArgs e)
        {
            buttonE.Visible = false;
            acertou = false;
            VerificarLetra('E');
            VerificarLetra('e');
            VerificarLetra('é');
            VerificarLetra('è');
            VerificarLetra('ê');
            AtualizarJogo();
        }

        private void buttonF_Click(object sender, System.EventArgs e)
        {
            buttonF.Visible = false;
            acertou = false;
            VerificarLetra('F');
            VerificarLetra('f');
            AtualizarJogo();
        }

        private void buttonG_Click(object sender, System.EventArgs e)
        {
            buttonG.Visible = false;
            acertou = false;
            VerificarLetra('G');
            VerificarLetra('g');
            AtualizarJogo();
        }

        private void buttonH_Click(object sender, System.EventArgs e)
        {
            buttonH.Visible = false;
            acertou = false;
            VerificarLetra('H');
            VerificarLetra('h');
            AtualizarJogo();
        }
    }
}


namespace TekkenGame.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TekkenGame.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TekkenGame.Models.TekkenDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(TekkenGame.Models.TekkenDB context)
        {
            var utilizadores = new List<Utilizadores> {
                new Utilizadores {ID=1, UserName ="tiago-rafael_98@hotmail.com", NomeCompleto = "Rafael André Campos Gonçalves", DataNascimento = new DateTime(1996,5,3),  Email = "tiago-rafael_98@hotmail.com"},
                new Utilizadores {ID=2, UserName ="racggoncalves@gmail.com", NomeCompleto = "Tiago Jorge Campos Gonçalves", Email = "tjorge@gmail.com", DataNascimento = new DateTime(1992,4,11)},
                new Utilizadores {ID=3, UserName ="racggoncalves@gmail.com", NomeCompleto = "Simão Pedro Oliveira Moleiro", Email = "symao96@gmail.com", DataNascimento = new DateTime(1996,10,2)},
                new Utilizadores {ID=4, UserName ="racggoncalves@gmail.com", NomeCompleto = "Beatriz Bangurá Okica de Sá", Email = "beatrizbokica@gmail.com", DataNascimento = new DateTime(1995,7,2)},
                new Utilizadores {ID=5, UserName ="racggoncalves@gmail.com" , NomeCompleto = "Patricia Sofia Margalhães Faustino", Email = "patricia.sofia.faustino@gmail.com", DataNascimento = new DateTime(1995,10,2)},
                new Utilizadores {ID=6, UserName ="racggoncalves@gmail.com", NomeCompleto = "Marta Andreia Campos Ribeiro", Email = "Mandreia@gmail.com", DataNascimento = new DateTime(1997,8,22)},
            };
            utilizadores.ForEach(dd => context.Utilizadores.AddOrUpdate(d => d.ID, dd));
            context.SaveChanges();

            // adiciona PLATAFORMAS
            var plataformas = new List<Plataformas> {
                new Plataformas {ID=1, Nome="Arcade", Logotipo="Arcade.jpg"},
                new Plataformas {ID=2, Nome="PlayStation", Logotipo="PlayStation.jpg"},
                new Plataformas {ID=3, Nome="PlayStation 2", Logotipo="PlayStation2.jpg"},
                new Plataformas {ID=4, Nome="PlayStation Portable", Logotipo="PlayStationPortable.jpg"},
                new Plataformas {ID=5, Nome="PlayStation 3", Logotipo="PlayStation3.jpg"},
                new Plataformas {ID=6, Nome="Xbox 360", Logotipo="Xbox360.jpg"},
                new Plataformas {ID=7, Nome="PlayStation 4", Logotipo="PlayStation4.jpg"},
                new Plataformas {ID=8, Nome="Xbox One", Logotipo="XboxOne.jpg"},
                new Plataformas {ID=9, Nome="Microsoft Windows", Logotipo="MicrosoftWindows.jpg"},
                new Plataformas {ID=10, Nome="Wii U", Logotipo="WiiU.jpg"},
            };
            plataformas.ForEach(cc => context.Plataformas.AddOrUpdate(c => c.ID, cc));
            context.SaveChanges();

            // adiciona JOGO
            var jogos = new List<Jogos> {
               new Jogos {ID=1, Titulo="Tekken", Logotipo="TekkenLogo.jpg", Fotografia="Tekken.jpg", Resumo="Um torneio mundial de artes marciais está a chegar ao fim, com uma grande quantia de prêmios em dinheiro concedida ao lutador que derrotar Heihachi Mishima na ronda final da competição. O concurso é patrocinado por uma grande empresa chamada o Mishima Zaibatsu. Há oito lutadores que permanecem após vencerem as partidas de morte em todo o mundo, com o vencedor do torneio recebendo o título de Rei do Punho de Ferro. Apenas um terá a chance de derrotar Heihachi e levar para casa o prêmio em dinheiro e a fama. Kazuya Mishima é a personagem principal. Filho biológico de Heihachi, ele foi jogado em uma ravina pelo seu pai quando tinha cinco anos de idade. Heihachi, acreditando que seu filho era fraco demais para herdar seu conglomerado, decidiu que, se fosse realmente forte o suficiente, seria capaz de sobreviver à queda e subir de volta. Kazuya sobreviveu. Alimentado pelo ódio por seu pai, ele entra no torneio para se vingar. Descubra como termina esta reviravolta!"},
               new Jogos {ID=2, Titulo="Tekken 2", Logotipo="Tekken2Logo.jpg", Fotografia="Tekken2.jpg", Resumo = "Kazuya Mishima venceu o torneio King of Iron Fist, atirando o seu pai pela ravina, e está na liderança da Mishima Zaibatsu. O torneio regressa com a sua segunda edição, agora com o prémio mil vezes maior. Quem conseguirá a liderança da Mishima Zaibatsu, Heihachi ou Kazuya?!" },
               new Jogos {ID=3, Titulo="Tekken 3", Logotipo="Tekken3Logo.jpg", Fotografia="Tekken3.jpg", Resumo="Após dezesseis anos do segundo Torneio King of Iron Fist, com a vitória de Heihachi, este estabeleceu a Tekken Force, uma organização dedicada à proteção do Mishima Zaibatsu. Um perigo ameaçou os soldados da Tekken Force, chamada de Ogre. Heihachi então decide procura-lo com o objetivo de dominar o mundo, com a ajuda do seu neto, Jin Kazama, que pretende vingança pelo desaparecimento da sua mãe. Descobre como terminará este enredo!" },
               new Jogos {ID=4, Titulo="Tekken 4", Logotipo="Tekken4Logo.jpg", Fotografia="Tekken4.jpg", Resumo="Jin, depois de conseguir derrotar o Ogre, lutou com o seu avô e derrotou-o pelo facto do mesmo o ter usado. Contudo, Heihachi continua na liderança da Mishima Zaibatsu e esta anunciou o Torneio King of Iron Fist 4 e colocou o enorme império financeiro como o principal prêmio. O campeão que conseguir derrotar Heihachi no final do Torneio herdará a Mishima Zaibatsu." },
               new Jogos {ID=5, Titulo="Tekken 5", Logotipo="Tekken5Logo.jpg", Fotografia="Tekken5.jpg", Resumo=" Uma nova personagem lidera Mishima Zaibatsu: Jinpachi Mishima. Pai de Heihachi Mishima, e, consequentemente, avô e bisavô de Kazuya e Jin Kazama. Jinpachi teria sido enterrado vivo pelo próprio filho para o mesmo liderar a sua empresa. Descobre quem o derrotará e terá a liderança da maior empresa do mundo! " },
               new Jogos {ID=6, Titulo="Tekken 5: Dark Resurrection", Logotipo="Tekken5DarkResurrectionLogo.jpg", Fotografia="Tekken5DarkResurrection.jpg", Resumo="O jogo segue exatamente o mesmo enredo de Tekken 5, apenas com as adições de dois novos personagens e um personagem que retorna; Emilie 'Lili' De Rochefort (que procura destruir o Mishima Zaibatsu e acabar com o problema financeiro de seu pai), Sergei Dragunov (um membro de Spetsnaz que foi enviado para capturar Jin) e Armor King II (que foi pensado para ter sido morto antes os eventos de Tekken 4 e cuja identidade e objetivos permanecem um mistério para o jogador)." },
               new Jogos {ID=7, Titulo="Tekken 6", Logotipo="Tekken6Logo.jpg", Fotografia="Tekken6.jpg", Resumo="Jin Kazama, que derrotou os seus parentes mais velhos, tomou a posse da Mishima Zaibatsu. Agora, Jin parece possuir ambições tirânicas. Usando seus recursos dentro da organização para se tornar uma superpotência global, ele separa os laços nacionais do Mishima Zaibatsu e abertamente declara guerra contra todas as nações no ano seguinte. Essa ação mergulha o mundo em uma espiral extremamente caótica, com uma guerra civil em grande escala em erupção ao redor do globo e até mesmo em meio às colônias espaciais que orbitam o planeta. Seu pai biológico, Kazuya Mishima, lidera a empresa rival de Zaibatsu, a G Corporation. Jogue para descobrir como irá acabar esta intensa guerra!." },
               new Jogos {ID=8, Titulo="Tekken 6: Bloodline Rebellion", Logotipo="Tekken6BloodlineRebellionLogo.jpg", Fotografia="Tekken6BloodlineRebellion.jpg", Resumo = "Tem o mesmo enredo que o Tekken 6, mas com a adição de duas novas personagens: Lars e Alisa Bosconovitch."},
               new Jogos {ID=9, Titulo="Tekken 7", Logotipo="Tekken7Logo.jpg", Fotografia="Tekken7.jpg", Resumo="Após os eventos de Tekken 6, a guerra entre a Mishima Zaibatsu e a G Corporation ainda continua junto com o desaparecimento de Jin Kazama. Com Heihachi na liderança da Mishima Zaibatsu após derrotar Nina (guarda de Jin que tem um papel importante na Mishima Zaibatsu), anuncia o torneio Torneio King of Iron Fist 7. As duas empresas procuram Jin e tentam expôr os podres uma da outra de forma a que cada uma vá à falência. Depois de muita confusão, Heihachi e Kazuya voltam a enfrentar-se para uma batalha final que termina na morte de um deles." },
               new Jogos {ID=10, Titulo="Tekken Tag Tournament", Logotipo="TekkenTagTournamentLogo.jpg", Fotografia="TekkenTagTournament.jpg", Resumo = "Não faz parte da história canónica do jogo. Chama-se 'Tag Team' por serem 2 lutadores contra 2 lutares ",},
               new Jogos {ID=11, Titulo="Tekken Tag Tournament 2", Logotipo="TekkenTagTournament2Logo.jpg", Fotografia="TekkenTagTournament2.jpg", Resumo = "Não faz parte da história canónica do jogo. Chama-se 'Tag Team' por serem 2 lutadores contra 2 lutares. É a segunda edição do 'Tekken Tag Tournament'.", },

            };
            jogos.ForEach(vv => context.Jogos.AddOrUpdate(v => v.ID, vv));
            context.SaveChanges();

            // adiciona PERSONAGENS

            var personagens = new List<Personagens> {
                new Personagens {ID=1, Nome="Kazuya Mishima", Origem="Japão", TipoLuta="Caratê de Combate estilo Mishima", Fotografia="Kazuya.jpg", Biografia = "Akuma é uma personagem convidada que aparece apenas em Tekken 7, e um dos principais antagonistas da série Street Fighter, outra série de jogos de luta. É um misterioso lutador, considerado um demônio. Ele se encontra no meio da guerra de sangue dos Mishima por um relacionamento pré-existente com Kazumi Mishima, a esposa de Heihachi. Ele faz sua a estréia em Tekken 7 prometendo cumprir uma dívida com Kazumi.", ListaDeJogos = new List<Jogos>{ jogos[0], jogos[1], jogos[3], jogos[4], jogos[5], jogos[6], jogos[7], jogos[8], jogos[9], jogos[10] } },

                new Personagens {ID=2, Nome="Nina Williams", Origem="Irlanda", TipoLuta="Artes de Assassinato baseadas no Aikido e no Koppojutsu", Fotografia="Nina.jpg",  Biografia = "Nina, juntamente com a sua irmã mais nova, Anna Williams, vêm de uma ilha da Irlanda. Sendo uma pessoa muito fria, Nina é uma assassína profissional. Ela entra nos Torneios do King Of Iron Fist sempre com o objetivo de matar um dos Mishimas.", ListaDeJogos = new List<Jogos>{ jogos[0], jogos[1], jogos[2], jogos[3], jogos[4], jogos[5], jogos[6], jogos[7], jogos[8], jogos[9], jogos[10] } },

                new Personagens {ID=3, Nome="Marshall Law",  Origem="Estados Unidos da América", TipoLuta="Artes Marciais", Fotografia="MarshallLaw.jpg", Biografia ="Marshall Law é um artista marcial muito talentoso. Ele é conhecido principalmente por possuir um dojo e um restaurante. Marshall é o melhor amigo de Paul Phoenix, apesar de discutirem muito. Law entra nos torneios para poder ganhar dinheiro para investir no seu restaurante.", ListaDeJogos = new List<Jogos>{ jogos[0], jogos[1], jogos[3], jogos[4], jogos[5], jogos[6], jogos[7], jogos[8], jogos[9], jogos[10] } },

                new Personagens {ID=4, Nome="Yoshimitsu", Origem ="Desconhecida", TipoLuta="Ninjutsu Manji Avançado", Fotografia="Yoshimitsu.jpg", Biografia = "Yoshimitsu é um lutador misterioso que pertence ao clã 'Manji Clã'. Este entrou no torneio para ser uma distração para os restantes membros do seu clã poderem roubar o prémio final sem que ninguém perceba.", ListaDeJogos = new List<Jogos>{ jogos[0], jogos[1], jogos[2], jogos[3], jogos[4], jogos[5], jogos[6], jogos[7], jogos[8], jogos[9], jogos[10] }},

                new Personagens {ID=5, Nome="Jack", Origem="Russia", TipoLuta="Força Bruta", Fotografia="Jack.jpg", Biografia="Construído pelos militares russos, Jack é uma máquina de matar construída puramente para destruição. Depois de provar-se no primeiro Torneio King of Iron Fist, robôs Jack atualizados foram colocados em produção em massa e utilizados em campos de batalha. Durante esse tempo, um dos robôs encontrou uma mulher jovem. De repente, desenvolvendo consciência, Jack-2 tomou para si a tarefa de cuidar da menina, até o ponto em que foi destruído pelo Doutor Abel. Depois disso, Jane, a jovem resgatada por Jack, cresceu determinada a restaurar o robô que a salvou quando criança. Embora Jane tenha conseguido instalar as memórias do Jack,o mesmo voltou a ser destruído. Depois disso, Jane entrou para a G Corporation, onde continuou a trabalhar na construção de robôs Jack, na esperança de restaurá-lo.", ListaDeJogos = new List<Jogos>{ jogos[0], jogos[1], jogos[2], jogos[4], jogos[5], jogos[6], jogos[7], jogos[8], jogos[9], jogos[10] }},

                new Personagens {ID=6, Nome="King",  Origem="México", TipoLuta="Pro-Wrestling", Fotografia="King.jpg", Biografia="King costumava ser um órfão de rua que lutava muito. Em uma de suas lutas, King foi gravemente ferido e caiu em frente a um mosteiro. Os padres Marquez o acolheram, salvando-o da morte. Depois de se recuperar, King percebeu o erro de seus caminhos e resolveu começar uma nova vida. Ele se tornou um padre católico e renunciou a seus velhos modos de luta. Ele sonhava em construir um orfanato para crianças de rua, na esperança de salvá-los de se tornar o tipo de lutador que ele costumava ser. King foi bem sucedido na construção de um orfanato, mas os fundos estavam apertados; Para trazer a renda para o orfanato, King lutou em combates de wrestling e, por fim, decidiu entrar nos torneios.", ListaDeJogos = new List<Jogos>{ jogos[0], jogos[1] }},

                new Personagens {ID=7, Nome="Anna Williams", Origem="Irlanda", TipoLuta="Técnicas baseadas em Aikido, Koppojutsu e artes de Assassinato", Fotografia="Anna.jpg", Biografia = "Embora tão habilidosa e mortal quanto Nina, ela tem uma personalidade que contrasta muito com o da sua irmã; Anna tem uma personalidade mais brincalhona, sedutora e mais sociável do que Nina, que, por sua vez, é introvertida, pensativa e de sangue frio. Anna tem uma rivalidade vingativa entre irmãos com sua irmã mais velha de vários anos. Essa rivalidade parece ter se intensificado após a morte de seu pai, Richard Williams, já que ambas se culpam uma à outra. Anna entra no torneio para ganhar o dinheiro e também por causa da sua irmã.", ListaDeJogos = new List<Jogos>{ jogos[0], jogos[1], jogos[2], jogos[4], jogos[5], jogos[6], jogos[7], jogos[9], jogos[10] }},

                new Personagens {ID=8, Nome="Ganryu", Origem="Japão", TipoLuta="Sumo", Fotografia="Ganryu.jpg", Biografia="Ganryu era um lutador talentoso, cuja força e talento no ringue permitiram que ele se tornasse o mais jovem lutador a alcançar o posto de ōzeki. Apesar de ter o talento para chegar facilmente ao posto de yokozuna, foi o seu estilo de vida fora do ringue que seria a sua queda, já que a sua atitude arrogante e seu hábito de jogo ilícito o levaram a ser desonrosamente dispensado das lutas de Sumo. Ainda determinado a provar que é o mais forte lutador do mundo, Ganryu entra no torneio para provar sua força..", ListaDeJogos = new List<Jogos>{ jogos[0], jogos[1], jogos[4], jogos[5], jogos[6], jogos[7], jogos[8], jogos[9], jogos[10] }},

                new Personagens {ID=9, Nome="Lee Chaolan", Origem="China", TipoLuta="Caraté de Combate estilo Mishima com Artes Marciais", Fotografia="Lee.jpg", Biografia="Lee é um homem incrivelmente presunçoso e arrogante com um imenso senso de classe, sem medo de exibir a sua riqueza. Embora excêntrico e intrigante como o seu pai adotivo, Heihachi, Lee tem, no fundo, bom caráter e tem um grande desprezo por Kazuya e Heihachi. Entra no torneio por tradição e também para ganhar o dinheiro", ListaDeJogos = new List<Jogos>{ jogos[0], jogos[1], jogos[3], jogos[4], jogos[5], jogos[6], jogos[7], jogos[8], jogos[9], jogos[10] }},

                new Personagens {ID=10, Nome="Prototype Jack", Origem="Rússia", TipoLuta="Força Bruta", Fotografia="PrototypeJack.jpg", Biografia="Em busca de uma arma nova e mais devastadora, os militares russos começaram a trabalhar no desenvolvimento de ciborgues - robôs sobre-humanos construídos com o propósito de causar destruição. O primeiro passo na produção foi o modelo protótipo do que viria a ser uma linha de robôs militares, que deveriam ser chamados de 'Jack'. Com o projeto um sucesso, os robôs Jack foram colocados em produção em massa, um dos quais foi inscrito no Torneio King of Iron Fist. Ao saber disso, o protótipo Jack foi inscrito no torneio por Heihachi Mishima para enfrentar o Jack principal.", ListaDeJogos = new List<Jogos>{ jogos[0], jogos[1], jogos[9], jogos[10] }},

                new Personagens {ID=11, Nome="Armor King", Origem="Desconhecida", TipoLuta="Pro-Wrestling", Fotografia="ArmorKing.jpg", Biografia="Armor King é o irmão mais velho de Armor King II, ambos lutadores. Armor King também viajou em busca de oponentes dignos para enfrentar, e em uma das lutas, ele se deparou com outro lutador em uma máscara de onça, chamado de 'King'. Intrigado, Armor King foi frente a frente com King em uma batalha feroz, no qual perdeu depois de sofrer uma lesão no olho. Amargurado por sua perda e pelo sucesso futuro de King, uma rivalidade se desenvolveu entre os dois. Armor King entra no torneio depois de saber que King lá estaria.",ListaDeJogos = new List<Jogos>{ jogos[0], jogos[1], jogos[9] }},

                new Personagens {ID=12, Nome="Kunimitsu", Origem="Japão", TipoLuta="Manji Ninjutsu", Fotografia="Kunimitsu.jpg", Biografia="Kunimitsu começou como um pequeno ladrão, mas depois se juntou ao Clã Manji para aprimorar suas habilidades. Renunciando a sua nacionalidade japonesa para permanecer anônima, ela treinou duro para aprender a arte do Ninjutsu Manji e melhorar suas habilidades de ladrões. Embora inicialmente respeitasse as regras do clã, roubando dos ricos e dando aos pobres, ela mais tarde começou a roubar os fundos do clã para seu próprio benefício. Quando foi pega, o líder, Yoshimitsu, baniu-a do clã. Kunimitsu entra no torneio para poder roubar o prémio final", ListaDeJogos = new List<Jogos>{ jogos[0], jogos[1], jogos[9], jogos[10] }},

                new Personagens {ID=13, Nome="Kuma", Origem="Japão", TipoLuta="Kuma Shinken estilo Heihachi", Biografia = "Kuma foi um filhote de urso encontrado abandonado nas florestas da propriedade de Mishima por Heihachi Mishima, que o aceitou como animal de estimação. Ao chegar à idade adulta, Kuma começou a mostrar um intelecto superior, e Heihachi, ao perceber isso, começou a treiná-lo, ensinando-lhe linguagem de sinais, técnicas de combate e japonês básico. Devido às habilidades impressionantes de Kuma, Heihachi fez dele o seu guarda-costas e Kuma acompanhou-o para o primeiro Torneio King of Iron Fist.", Fotografia="Kuma.jpg", ListaDeJogos = new List<Jogos>{ jogos[0], jogos[1] }},

                new Personagens {ID=14, Nome="Heihachi Mishima", Origem="Japão", TipoLuta="Caraté de Combate estilo Mishima", Fotografia="Heihachi.jpg", Biografia="Heihachi Mishima é o anfitrião do 1º, 3º, 4º e 7º torneios do King of Iron Fist. Ele é filho de Jinpachi Mishima, servindo como lutador final do 1º e 4º torneios. Ele é pai de Kazuya Mishima e Lars Alexandersson, pai adotivo de Lee Chaolan, avô de Jin Kazama, e o marido de Kazumi Mishima. O estilo de luta de Heihachi é o Mishima Style Fighting Karate. Ele também é o 'Comandante' inaugural da Unidade Tekken Force, estabelecendo a unidade entre o 2º e 3º torneios.", ListaDeJogos = new List<Jogos>{ jogos[0], jogos[1], jogos[2], jogos[3], jogos[4], jogos[5], jogos[6], jogos[7], jogos[8], jogos[9], jogos[10] }},

                new Personagens {ID=15, Nome="Paul", Origem="Estados Unidos da América", TipoLuta="Judo", Fotografia="Paul.jpg", Biografia="Paul Phoenix é um lutador americano conhecido por ser bastante 'durão'. Não tem nenhuma carreira real, só se mete em brigas de rua e tem um trabalho ocasional como um segurança enquanto persegue a sua verdadeira paixão - provar que ele é o mais duro lutador do universo. Paul treina com Marshall Law, que se torna seu amigo, e Lee Chaolan. Porém, um dia foi derrotado por um home chamado Kazuya. Quando Paul ouve o anúncio de um Torneio King of Iron Fist, ele entra, vendo a oportunidade de enfrentar seu antigo rival e provar que é o melhor. ", ListaDeJogos = new List<Jogos>{ jogos [0], jogos[1], jogos[2], jogos[3], jogos[4], jogos[5], jogos[6], jogos[7], jogos[8], jogos[9], jogos[10] }},

                new Personagens {ID=16, Nome="Devil Kazuya", Origem="Desconhecida", TipoLuta="Caraté de Combate estilo Mishima", Fotografia="DevilKazuya.jpg", Biografia="Nasceu como a alma amaldiçoada de Kazuya, Devil é uma entidade implacável, motivada pelo poder acima de tudo, e gosta de causar dor a outras pessoas. Ele não demonstra nenhum remorso pelo dano que causa aos outros em sua busca por poder absoluto e controle sobre o mundo. Ele também é extremamente arrogante, pois acredita que seu poder é inigualável.",  ListaDeJogos = new List<Jogos>{ jogos[0], jogos[1], jogos[8],  jogos[9], jogos[10] }},

                new Personagens {ID=17, Nome="Michelle Chang", Origem="Estados Unidos da América", TipoLuta="Xin Yi Liu He Quan e Baji Quan baseado em artes marciais chinesas", Fotografia="Michelle.jpg", Biografia="Michelle Chang é uma jovem nativa americana de descendência mista; seu pai é um homem de Hong Kong, enviado para a América por Heihachi Mishima com a tarefa de encontrar um tesouro em terras nativas americanas. Em vez de tesouro, ele encontrou romance e ficou na América para se casar com seu novo amor. Michelle nasceu pouco depois, e eles viveram juntos felizes até que, no seu décimo oitavo aniversário, Michelle descobre da mãe que o seu pai foi morto pelos homens de Heihachi. Indignada, Michelle entra no primeiro Torneio King of Iron Fist determinado a se vingar de Heihachi.",  ListaDeJogos = new List<Jogos>{ jogos[0], jogos[1], jogos[9], jogos[10] }},

                new Personagens {ID=18, Nome="Jun Kazama", Origem="Japão", TipoLuta="Artes marciais tradicionais estilo Kazama", Fotografia="Jun.jpg", Biografia="Pouco se sabe acerca da personalidade de Jun para além das poucas dicas que outras personagens deram ao longo da série. Kazuya descreve-a como 'misteriosa'. Jun parece incorporar tranquilidade e pureza e demonstra ter uma natureza pacífica e amorosa animal.",  ListaDeJogos = new List<Jogos>{ jogos[1], jogos[9], jogos[10] }},

                new Personagens {ID=19, Nome="Lei Wulong", Origem="Hong Kong", TipoLuta="Five Animals Form e Drunken Boxing baseado em artes marciais chinesas", Fotografia="Lei.jpg", Biografia="Um homem que vive para o seu trabalho. Dedicado ao ponto de obsessão, Lei é um policial cumpridor e talentoso. É justo e afável para aqueles ao seu redor, a menos que eles violem a lei. Trata os seus amigos, como Wang Jinrei e Steve Fox, com compaixão e respeito. Para seus inimigos, no entanto, ele alcança uma abordagem direta e severa. Embora as suas tentativas possam às vezes ser desajeitadas, as intenções de Lei são sempre virtuosas por natureza.",  ListaDeJogos = new List<Jogos>{ jogos[1], jogos[2], jogos[3], jogos[4], jogos[5], jogos[6], jogos[7], jogos[9], jogos[10] }},

                new Personagens {ID=20, Nome="Wang Jinrei", Origem="China", TipoLuta="Xin Yi Liu He Quan", Fotografia="Wang.jpg", Biografia="Wang Jinrei é um velho corajoso que tem um coração gentil. Wang continuou a ser generoso e gentil enquanto vivia recluso nos jardins de Mishima. Wang era um amigo próximo do pai de Heihachi Mishima, Jinpachi Mishima. Após a morte de Jinpachi, ele colocou sua fé em Heihachi. No entanto, Wang não sabe das ações de Heihachi.", ListaDeJogos = new List<Jogos>{ jogos [0], jogos[1], jogos[4], jogos[5], jogos[6], jogos[7], jogos[9], jogos[10] }},

                new Personagens {ID=21, Nome="Roger", Origem="Amostra de DNA retirada de um canguru", TipoLuta="Commando Wrestling", Fotografia="Roger.jpg", Biografia="O Roger original, que apareceu pela primeira vez em Tekken 2, é um canguru geneticamente modificado com a capacidade de lutar. Roger Jr., o seu filho, substitui o Roger original a partir do Tekken 5.",  ListaDeJogos = new List<Jogos>{ jogos[1], jogos[9] }},

                new Personagens {ID=22, Nome="Alex", Origem="Amostra de DNA retirada de um inseto", TipoLuta="Commando Wrestling", Fotografia="Alex.jpg", ListaDeJogos = new List<Jogos>{ jogos[1], jogos[9], jogos[10] }},

                new Personagens {ID=23, Nome="Baek Doo San", Origem="Coreia do Sul", TipoLuta="Taekwondo", Fotografia="Baek.jpg", Biografia="Alex é um Dromaeosaurid clonado criado por Doctor Bosconovitch durante o mandato de Kazuya Mishima como o chefe do Mishima Zaibatsu. Alex foi criado pela combinação de DNA de dinossauro de um fóssil com o DNA de um canguru. Após sua criação, Alex foi treinado por Armor King.", ListaDeJogos = new List<Jogos>{ jogos[1], jogos[4], jogos[5], jogos[6], jogos[7], jogos[9], jogos[10] }},

                new Personagens {ID=24, Nome="Bruce Irvin", Origem="Estados Unidos da América", TipoLuta="Muay Thai", Fotografia="Bruce.jpg", Biografia="Bruce Irvin nasceu e cresceu em um bairro perigoso, atormentado por criminosos e gângsteres. Quando jovem, Bruce ficou sem a sua família quando os seus pais e irmão mais velho foram atacados e mortos por gangsters. Com nenhuma outra família a quem recorrer, Bruce foi forçado a sobreviver sozinho nas ruas. Sabendo que ele tinha que ser forte para sobreviver, Bruce treinou na arte do kickboxing de Muay Thai. Forçado a lutar diariamente para sobreviver nas ruas, Bruce transformou isso em vantagem ao competir na cena de luta underground para ganhar dinheiro, onde logo desenvolveu uma reputação assustadora devido ao seu temperamento vicioso e técnica inflexível. Isso levou Bruce a competir em torneios profissionais, onde logo se tornou o indiscutível campeão dos pesos pesados.", ListaDeJogos = new List<Jogos>{ jogos[1], jogos[4], jogos[5], jogos[6], jogos[7], jogos[9], jogos[10] }},

                new Personagens {ID=25, Nome="Jin Kazama", Origem="Japão", TipoLuta="Caraté de luta avançada estilo Mishima com artes marciais tradicionais estilo Kazama", Fotografia="Jin.jpg", Biografia="Jin Kazama é filho de Jun Kazama e Kazuya Mishima. O relacionamento íntimo de Jun com Kazuya cresceu e ela ficou grávida de Jin. O diabo dentro de Kazuya tentou entrar em Jin enquanto ele ainda estava no ventre da sua mãe, mas Jun conseguiu combatê-lo. Posteriormente, Jun mudou-se para um local remoto nas montanhas, onde criou Jin e o treinou no estilo de luta de autodefesa da família Kazama. Um dia, a sua mãe desapareceu devido ao ataque de um ser misterioso. Então Jin recorre ao seu avô, Heihachi, para aprender a lutar e entrar no torneio para se vingar.",  ListaDeJogos = new List<Jogos>{ jogos[2], jogos[3], jogos[4], jogos[5], jogos[6], jogos[7], jogos[8], jogos[9], jogos[10] }},

                new Personagens {ID=26, Nome="Mokujin", Origem="Japão", TipoLuta="Mimicry", Fotografia="Mokujin.jpg", Biografia="Mokujin é um manequim de treinamento de madeira, construído de carvalho branco há mais de 2000 anos para os artistas marciais praticarem as suas habilidades. Uma relíquia do passado, Mokujin foi exibido em um museu até que, um dia, o Deus da Luta despertou, trazendo um intenso mal ao mundo. Esse despertar também acordou Mokujin, fazendo com que ele desenvolvesse uma mente própria e começasse a se mover, e deixou o museu para ajudar os artistas marciais de hoje em sua batalha do bem contra o mal ao entrar no terceiro Torneio King of Iron Fist. Quando Ogre foi derrotado e o mal foi derrotado, Mokujin voltou a dormir e foi devolvido ao museu.", ListaDeJogos = new List<Jogos>{ jogos[2], jogos[4], jogos[5], jogos[6], jogos[9], jogos[10] }},

                new Personagens {ID=27, Nome="Forest Law", Origem="Estados Unidos da América", TipoLuta="Artes marciais baseadas em Jeet Kune Do", Fotografia="ForestLaw.jpg", Biografia="Como seu pai, Forest é um artista marcial muito talentoso. Ele é aluno do Marshall Dojo e trabalhou para o pai em Marshall China. O Forest Law cresceu com o pai e a mãe. Forest começou o seu treinamento junto com seu pai em uma idade jovem. Forest se tornaria a melhor aluna de Marshall no dojo. Apesar de sua habilidade, Marshall proibia seu filho de lutar em competições fora do dojo sem o seu consentimento.Só que, um dia, Paul levou Forest para outro caminho. Paul e Forest entram no Torneio King of Iron Fist 3 sem o consentimento do seu pai.",  ListaDeJogos = new List<Jogos>{ jogos[2], jogos[9], jogos[10] }},

                new Personagens {ID=28, Nome="King II", Origem="México",  TipoLuta="Pro-Wrestling", Fotografia="KingII.jpg", Biografia="o King II foi criado no orfanato do primeiro King. Até os 24 anos de idade, trabalhou com King até que, um dia, a notícia da morte deste mudou a vida de King II. Vendo que o orfanato iria desmoronar em ruínas, este homem vestiu a máscara de King, porém não tinha as habilidades de King. No entanto, outro homem com uma máscara visitou o King II, apresentando-se como um velho amigo. Este homem revelou-se ser o Armor King, antigo amigo de King, que treinou King II. Assim que se sentiu preparado, King II começou a entrar nos torneios King of Iron Fist.", ListaDeJogos = new List<Jogos>{ jogos[2], jogos[3], jogos[4], jogos[5], jogos[6], jogos[7], jogos[8], jogos[9], jogos[10] }},

                new Personagens {ID=29, Nome="Ling Xiaoyu", Origem="China", TipoLuta="Baguazhang e Piguaquan baseados em artes marciais chinesas", Fotografia="Xiaoyu.jpg", Biografia="Xiaoyu é uma jovem de 16 anos que adora parques de diversões. Esta nasceu na China e tem um panda chamada Panda como animal de estimação. Xiaoyu quis entrar no Torneio como o primeiro passo para angariar dinheiro para poder construir o parque de diversões de sonhos na China.", ListaDeJogos = new List<Jogos>{ jogos[2], jogos[3], jogos[4], jogos[5], jogos[6], jogos[7], jogos[8], jogos[9], jogos[10] }},

                new Personagens {ID=30, Nome="Julia Chang", Origem="Estados Unidos da América", TipoLuta="Xin Yi Liu He Quan e Baji Quan baseados em artes marciais chinesas", Fotografia="Julia.jpg", Biografia="Julia foi abandonada, quando era um bebê, numa floresta da américa. A sua sorte mudou, no entanto, quando ela foi encontrada por Michelle Chang, uma jovem de uma tribo nativa que a adotou e a criou como se fosse sua filha. Julia cresceu com um forte amor por sua mãe e tribo adotiva, e foi ensinada a lutar para proteger sua terra natal. Julia também desenvolveu um fascínio pela herança de suas tribos e começou a estudar arqueologia para aprender mais sobre seus antepassados. Com o desaparecimento da sua mãe, Julia entra no terceio torneio para ganhar dinheiro e investigar o desaparecimento da sua mãe adotiva.", ListaDeJogos = new List<Jogos>{ jogos[2], jogos[3], jogos[4], jogos[5], jogos[6], jogos[7], jogos[9], jogos[10] }},

                new Personagens {ID=31, Nome="Hwoarang", Origem="Coreia do Sul", TipoLuta="Taekwondo", Fotografia="Hwoarang.jpg", Biografia="O hwoarang é uma pessoa impulsiva e de cabeça quente que gosta de lutar. Ele às vezes é arrogante e ousado, pois gosta de se gabar de suas habilidades e força. Ele ainda mantém seu foco em seus oponentes para não se perder em seu orgulho. Ele é muito rebelde e não gosta de obedecer ordens, mas isso muda em relação ao seu mestre, Baek, a quem ele respeita profundamente. Hwoarang tende a guardar rancor em relação aos seus inimigos, e ele tem um forte senso de determinação para lutar contra seus rivais, especialmente Jin Kazama.", ListaDeJogos = new List<Jogos>{ jogos[2], jogos[3], jogos[4], jogos[5], jogos[6], jogos[7], jogos[8], jogos[9], jogos[10] }},

                new Personagens {ID=32, Nome="Eddy Gordo", Origem="Brasil", TipoLuta="Capoeira", Fotografia="Eddy.jpg", Biografia="Eddy nasceu em uma das famílias mais ricas do Brasil.. Um dia, quando ele tinha 19 anos, Eddy chegou a casa e encontrou seu o seu pai morto. O pai de Eddy estava trabalhando para destruir um negócio de drogas no Brasil na época. Eddy descobre que também o seu pai estava a trabalhar para a Mishima Zaibatsu, encarregue por Kazuya Mishima, descobrindo também que o seu pai foi morto por este. Eddy treinou durante oito anos e entrou no torneio para se vingar de Kazuya.",  ListaDeJogos = new List<Jogos>{ jogos[2], jogos[3], jogos[4], jogos[5], jogos[6], jogos[7], jogos[8], jogos[9], jogos[10] }},

                new Personagens {ID=33, Nome="Bryan Fury", Origem="Estados Unidos da América", TipoLuta="Kickboxing", Fotografia="Bryan.jpg", Biografia="Bryan é insensível, psicopata e egoísta em geral. Ao longo de toda a série, fica claro que a motivação de Bryan nada mais é do que criar estragos e miséria onde quer que ele vá. O seu egoísmo foi mostrado várias vezes, como quando ele traiu Doctor Bosconovitch e Yoshimitsu muito pouco depois de Yoshimitsu salvou-o da morte.", ListaDeJogos = new List<Jogos>{ jogos[2], jogos[3], jogos[4], jogos[5], jogos[6], jogos[7], jogos[8], jogos[9], jogos[10] }},

                new Personagens {ID=34, Nome="Kuma II", Origem="Japão", TipoLuta="Kuma Shinken estilo Heihachi", Fotografia="KumaII.jpg", Biografia="Kuma II substituiu Kuma I, o seu pai, que morreu de velhice logo após o segundo torneio. Assim como o seu pai, o segundo Kuma é o animal de estimação e guarda-costas de Heihachi Mishima. Kuma está apaixonado pela Panda, animal de estimação de Xiaoyu, mas ela não sente o mesmo nem tem qualquer interesse nele. ",  ListaDeJogos = new List<Jogos>{ jogos[2], jogos[3], jogos[4], jogos[5], jogos[6], jogos[7], jogos[8], jogos[9], jogos[10] }},

                new Personagens {ID=35, Nome="Ogre", Origem="Desconhecida", TipoLuta="Toshin", Fotografia="Ogre.jpg", Biografia="Embora Ogre pareça ser um animal selvagem, ele é na verdade um ser sensível. Muito pouca informação é dada sobre a personalidade ou história da personagem. Ogre 'entende estruturas inteiras de todos os seres vivos e artificiais, e absorve-as'. Em sua primeira forma, Ogre é capaz de falar, mas fala em uma língua extraterrestre desconhecida. ",  ListaDeJogos = new List<Jogos>{ jogos[2], jogos[9], jogos[10] }},

                new Personagens {ID=36, Nome="True Ogre", Origem="Desconhecida", TipoLuta="Desconhecida", Fotografia="TrueOgre.jpg", Biografia="Ele é mais um animal uivante nesta sua forma. Ele perde sua capacidade de falar, aos poucos ruge e simplesmente parece apenas atacar e absorver aqueles que vêm confrontá-lo. Ironicamente, nesta forma, True Ogre se comporta como um animal selvagem.",  ListaDeJogos = new List<Jogos>{ jogos[2], jogos[9], jogos[10] }},

                new Personagens {ID=37, Nome="Panda", Origem="China", TipoLuta="Kuma Shinken estilo Heihachi", Fotografia="Panda.jpg", Biografia="Protetora de Ling Xiaoyu, Pandala é cuidada por Xiaoyu e leva-a à escola. Para participar do torneio, Xiaoyu mudou.se para a universidade 'Mishima Industrial', no Japão. Heihachi Mishima ensinou Panda um tipo de luta chamado 'Advanced Bear Fighting ' para que ela pudesse atuar como guarda-costas para Xiaoyu durante o torneio. Embora Kuma goste da Panda, ela não gosta dele e mantém distância.", ListaDeJogos = new List<Jogos>{ jogos[2], jogos[3], jogos[4], jogos[5], jogos[6], jogos[7], jogos[8], jogos[9], jogos[10] }},

                new Personagens {ID=38, Nome="Tiger Jackson", Origem="Desconhecida", TipoLuta="Capoeira", Fotografia="TigerJackson.jpg", Biografia="Tiger Jackson é o primo de Eddy Gordo. Jackson não tem um enredo próprio dentro do jogo.", ListaDeJogos = new List<Jogos>{ jogos[2], jogos[9], jogos[10] }},

                new Personagens {ID=39, Nome="Doctor Bosconovitch", Origem="Rússia", TipoLuta="Tudo o que ele sabe", Fotografia="DoctorBosconovitch.jpg", Biografia="Doctor Bosconovitch é um doutor que já ajudou algumas outras personagens do jogo. Amigo de Yoshimitsu, este ressuscitou o cyborg Bryan Fury e criou Alisa Bosconovitch, a quem considera sua filha.",  ListaDeJogos = new List<Jogos>{ jogos[2], jogos[10] }},

                new Personagens {ID=40, Nome="Gon", Origem="Desconhecida", TipoLuta="Desconhecida", Fotografia="Gon.jpg", Biografia="Gon é um dinossauro pequeno e silencioso de espécie desconhecida. Com a extinção de outros da sua espécie, Gon de alguma forma sobreviveu e agora passa o seu tempo viajando pelo mundo, explorando novos ambientes e interagindo com outros animais que encontra. Gon é muito forte, sendo capaz de erguer objetos muito mais pesados do que ele e tem uma pele dura, quase impenetrável.", ListaDeJogos = new List<Jogos>{ jogos[2] }},

                new Personagens {ID=41, Nome="Christie Monteiro", Origem="Brasil", TipoLuta="Capoeira", Fotografia="Christie.jpg", Biografia="123", ListaDeJogos = new List<Jogos>{ jogos[3], jogos[4], jogos[5], jogos[6], jogos[7], jogos[10] }},

                new Personagens {ID=42, Nome="Craig Marduk", Origem="Austrália", TipoLuta="Vale Tudo", Fotografia="Marduk.jpg", Biografia="123", ListaDeJogos = new List<Jogos>{ jogos[3], jogos[4], jogos[5], jogos[6], jogos[7], jogos[10] }},

                new Personagens {ID=43, Nome="Steve Fox", Origem="Reino Unido", TipoLuta="Box", Fotografia="Steve.jpg", Biografia="123", ListaDeJogos = new List<Jogos>{ jogos[3], jogos[4], jogos[5], jogos[6], jogos[7], jogos[8], jogos[10] }},

                new Personagens {ID=44, Nome="Combot", Origem="Frabicado pela Violet Systems", TipoLuta="Mimicry", Biografia="123", Fotografia="Combot.jpg", ListaDeJogos = new List<Jogos>{ jogos[3], jogos[10] }},

                new Personagens {ID=45, Nome="Violet", Origem="Japão", TipoLuta="Artes marciais baseadas em Jeet Kune Do", Biografia="123", Fotografia="Violet.jpg", ListaDeJogos = new List<Jogos>{ jogos[3], jogos[8], jogos[10] }},

                new Personagens {ID=46, Nome="Miharu Hirano", Origem="Japão", TipoLuta="Baguazhang e Piguaquan baseados em artes marciais chinesas", Fotografia="Miharu.jpg", Biografia="123",  ListaDeJogos = new List<Jogos>{ jogos[3], jogos[10] }},

                new Personagens {ID=47, Nome="Feng Wei", Origem="China", TipoLuta="Artes marciais do estilo God Fist", Fotografia="Feng.jpg", Biografia="123", ListaDeJogos = new List<Jogos>{ jogos[4], jogos[5], jogos[6], jogos[7], jogos[8], jogos[10] }},

                new Personagens {ID=48, Nome="Asuka Kazama", Origem="Japão", TipoLuta="Artes marciais tradicionais estilo Kazama", Fotografia="Asuka.jpg", Biografia="123", ListaDeJogos = new List<Jogos>{ jogos[4], jogos[5], jogos[6], jogos[7], jogos[8], jogos[10] }},

                new Personagens {ID=49, Nome="Raven", Origem="Desconhecida", TipoLuta="Ninjutsu", Fotografia="Raven.jpg", Biografia="123", ListaDeJogos = new List<Jogos>{ jogos[4], jogos[5], jogos[6], jogos[7], jogos[10] }},

                new Personagens {ID=50, Nome="Devil Jin", Origem="Desconhecida", TipoLuta="Caraté de luta avançada estilo Mishima com artes marciais tradicionais estilo Kazama", Fotografia="DevilJin.jpg", Biografia="123",  ListaDeJogos = new List<Jogos>{ jogos[4], jogos[5], jogos[6], jogos[7], jogos[8], jogos[10] }},

                new Personagens {ID=51, Nome="Roger Jr.", Origem="Desconhecida", TipoLuta="Commando Wrestling", Fotografia="RogerJr.jpg", Biografia="123", ListaDeJogos = new List<Jogos>{ jogos[4], jogos[5], jogos[6], jogos[7], jogos[10] }},

                new Personagens {ID=52, Nome="Jinpachi Mishima", Origem="Japão", TipoLuta="Caraté de Combate estilo Mishima", Fotografia="Jinpachi.jpg", Biografia="123", ListaDeJogos = new List<Jogos>{ jogos[5], jogos[10] }},

                new Personagens {ID=53, Nome="Armor King II", Origem="Irlanda", TipoLuta="Pro-Wrestling", Fotografia="ArmorKingII.jpg", Biografia="123", ListaDeJogos = new List<Jogos>{ jogos[5], jogos[6], jogos[7], jogos[10] }},

                new Personagens {ID=54, Nome="Lili De Rochefort", Origem="Monaco", TipoLuta="Auto-ensinada", Fotografia="Lili.jpg",Biografia="123",  ListaDeJogos = new List<Jogos>{ jogos[5], jogos[6], jogos[7], jogos[8], jogos[10] }},

                new Personagens {ID=55, Nome="Sergei Dragrunov", Origem="Rússia", TipoLuta="Commando Sambo", Fotografia="Sergei.jpg", Biografia="123", ListaDeJogos = new List<Jogos>{ jogos[5], jogos[6], jogos[7], jogos[8], jogos[10] }},

                new Personagens {ID=56, Nome="Alisa Bosconovitch", Origem="Rússia", TipoLuta="Combate de alta mobilidade usando propulsores", Fotografia="Alisa.jpg", Biografia="123",  ListaDeJogos = new List<Jogos>{ jogos[7], jogos[8], jogos[10] }},

                new Personagens {ID=57, Nome="Bob Richards", Origem="Estados Unidos da América", TipoLuta="Karaté Freestyle", Fotografia="Bob.jpg", Biografia="123", ListaDeJogos = new List<Jogos>{ jogos[6], jogos[7], jogos[8], jogos[10] }},

                new Personagens {ID=58, Nome="Lars Alexandersson", Origem="Suécia", TipoLuta="Karaté e Artes Marciais Tekken Forces", Fotografia="Lars.jpg", Biografia="123", ListaDeJogos = new List<Jogos>{ jogos[7], jogos[8], jogos[10] }},

                new Personagens {ID=59, Nome="Leo Kliesen", Origem="Alemanha", TipoLuta="Baji Quan", Fotografia="Leo.jpg", Biografia="123", ListaDeJogos = new List<Jogos>{ jogos[6], jogos[7], jogos[8], jogos[10] } },

                new Personagens {ID=60, Nome="Miguel Rojo", Origem="Espanha", TipoLuta="Não definido (Luta de rua)", Fotografia="Miguel.jpg", Biografia="123",  ListaDeJogos = new List<Jogos>{ jogos[6], jogos[7], jogos[8], jogos[10] } },

                new Personagens {ID=61, Nome="Zafina", Origem="Egipto", TipoLuta="Artes antigas de Assassinato", Biografia="123", Fotografia="Zafina.jpg", ListaDeJogos = new List<Jogos>{ jogos[6], jogos[7], jogos[8], jogos[10] } },

                new Personagens {ID=62, Nome="Akuma", Origem="Japão", TipoLuta="Artes Marciais", Fotografia="Akuma.jpg", Biografia="123", ListaDeJogos = new List<Jogos>{ jogos[8] } },

                new Personagens {ID=63, Nome="Claudio Serafino", Origem="Itália", TipoLuta="Feitiçaria de Exorcismo estilo Sirius", Fotografia="Claudio.jpg", Biografia="123", ListaDeJogos = new List<Jogos>{ jogos[8] } },

                new Personagens {ID=64, Nome="Geese Howard", Origem="Estados Unidos da América", TipoLuta="Kobujutsu", Fotografia="Geese.jpg", Biografia="123", ListaDeJogos = new List<Jogos>{ jogos[8] } },

                new Personagens {ID=65, Nome="Gigas", Origem="Desconhecida", TipoLuta="Impulso Destrutivo", Fotografia="Gigas.jpg", Biografia="123", ListaDeJogos = new List<Jogos>{ jogos[8] } },

                new Personagens {ID=66, Nome="Josie Rizal", Origem="Filipinas", TipoLuta="Kickboxing baseado em Eskrima", Fotografia="Josie.jpg", Biografia="123", ListaDeJogos = new List<Jogos>{ jogos[8] } },

                new Personagens {ID=67, Nome="Katarina Alves", Origem="Brasil", TipoLuta="Savate", Fotografia="Katarina.jpg", Biografia="123", ListaDeJogos = new List<Jogos>{ jogos[8] } },

                new Personagens {ID=68, Nome="Kazumi Mishima", Origem="Arábia Saudita", TipoLuta="Karaté estilo Hachijo misturado com Karaté de Combato estilo Mishima", Fotografia="Kazumi.jpg", Biografia="123", ListaDeJogos = new List<Jogos>{ jogos[8] } },

                new Personagens {ID=69, Nome="Shaheen", Origem="Irlanda", TipoLuta="Estilo militar de combate", Biografia="123", Fotografia="Shaheen.jpg", ListaDeJogos = new List<Jogos>{ jogos[8] } },

                new Personagens {ID=70, Nome="Master Raven", Origem="Desconhecida", TipoLuta="Ninjutsu", Biografia="123", Fotografia="MasterRaven.jpg", ListaDeJogos = new List<Jogos>{ jogos[8] } },

                new Personagens {ID=71, Nome="Noctis Lucis Caelum", Origem="Irlanda", TipoLuta="Weapon Summoning", Biografia="123", Fotografia="Noctis.jpg", ListaDeJogos = new List<Jogos>{ jogos[8] } },

                new Personagens {ID=72, Nome="Lucky Chloe", Origem="Desconhecida", TipoLuta="Dança Freestyle e acrobática", Fotografia="LuckyChloe.jpg", Biografia="123",  ListaDeJogos = new List<Jogos>{ jogos[8] } },

                new Personagens {ID=73, Nome="Tetsujin", Origem="Desconhecida", TipoLuta="Mimicry", Fotografia="Tetsujin.jpg", Biografia="123",  ListaDeJogos = new List<Jogos>{ jogos[9] } },

                new Personagens {ID=74, Nome="Unknown", Origem="Desconhecida", TipoLuta="Mimicry",  Fotografia="Unknown.jpg", Biografia="123",  ListaDeJogos = new List<Jogos>{ jogos[9], jogos[10] } },

                new Personagens {ID=75, Nome="Jaycee", Origem="Estados Unidos da América", TipoLuta="Pro-Wrestling, Xin Yi Liu He Quan e Baji Quan baseados em artes marciais chinesas", Fotografia="Jaycee.jpg", Biografia="123",  ListaDeJogos = new List<Jogos> { jogos[10] } },

                new Personagens {ID=76, Nome="Sebastian", Origem="Monaco", TipoLuta="Dança Freestyle e acrobática", Fotografia="Sebastian.jpg", Biografia="123",  ListaDeJogos = new List<Jogos>{ jogos[10] } },

                new Personagens {ID=77, Nome="Slim Bob", Origem="Estados Unidos da América", TipoLuta="Karaté estilo livre", Fotografia="SlimBob.jpg", Biografia="123",  ListaDeJogos = new List<Jogos>{ jogos[10] } },

                new Personagens {ID=78, Nome="Negan", Origem="Estados Unidos da América", TipoLuta="Não definido. Utiliza a Lucile, a sua arma branca, para lutar.", Fotografia="Negan.jpg", Biografia="123",  ListaDeJogos = new List<Jogos>{ jogos[8] } },

            };
            personagens.ForEach(aa => context.Personagens.AddOrUpdate(a => a.ID, aa));
            context.SaveChanges();
        }
    }
}

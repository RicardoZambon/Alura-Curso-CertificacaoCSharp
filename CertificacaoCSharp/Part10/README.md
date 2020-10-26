<img src="Image01.png" />

Chegamos ao final da parte 10 do nosso curso de certifica��o 70-483 Programa��o em C-Sharp. Vamos, ent�o, fazer uma revis�o bem r�pida das coisas que a gente aprendeu aqui.

<img src="Image02.png" />

<img src="Image03.png" />

N�s come�amos a ver sobre a cria��o e aplica��o de atributos. Ent�o, n�s vimos que os atributos eles s�o metadados, eles s�o informa��es sobre informa��es, eles s�o dados sobre dados, que podem ser acrescentados a tipos, como, por exemplo, uma classe ou ent�o a um membro da classe, como um campo ou uma propriedade ou um m�todo.

Ent�o, a gente aprendeu sobre isso aqui no c�digo, quando o nosso trabalhamos com a classe venda. A classe venda ela possui alguns atributos, que s�o, por exemplo, o Serializable, que � um atributo de classe, e aqui embaixo o NonSerialized, que � um atributo de campo. N�s aprendemos a utilizar esses dois atributos, que j� v�m imbutidos no .NET.

E aprendemos tamb�m a criar atributos novos, declarando duas classes novas, que s�o o formato resumido e o formato detalhado. N�s aprendemos que esses atributos customizados eles precisam ser declarados aqui como classes, como � o caso de FormatoResumidoAttribute, e esse tipo de classe precisa herdar da classe base atributo.

Aprendemos, tamb�m, que esse tipo de atributo ele precisa ter um formato ou um modo de utiliza��o. No nosso caso, nossos atributos eles s�o decorados com outro atributo, chamado de AttributeUsage ou utiliza��o do atributo que foi definido com um target, ou um alvo, que � a classe. Ou seja, n�s limitamos o uso dele somente a classes. E n�s definimos, tamb�m, que esse tipo de atributo s� pode ser utilizado uma vez, marcando o AllowMultiple como falso.

<img src="Image04.png" />

E n�s vimos, tamb�m, como ler atributos. N�s aprendemos a ler os atributos, como, por exemplo, o atributo que foi adicionado � classe de venda, n�s fizemos essa leitura aqui no Item2. Ent�o, no Item2 - Ler os atributos, n�s abrimos a classe relat�rio e l� dentro, no momento de fazer a impress�o, n�s decidimos qual o formato de impress�o utilizar atrav�s da declara��o de uma vari�vel atributo.

Essa vari�vel atributo vai pegar l� dentro do atributo da classe de venda atrav�s do m�todo GetCustomAttribute, passando o tipo da classe venda e tamb�m o tipo da classe que comp�e o atributo. E, no final, n�s pegamos a informa��o desse atributo, acessando a propriedade formato do formato detalhado.

<img src="Image05.png" />

<img src="Image06.png" />

N�s vimos tamb�m, em seguida, como utilizar reflection, que � uma maneira de fazer o c�digo olhar para dentro de si mesmo ou investigar outras classes e outros tipos. N�s vimos, por exemplo, aqui no Item03 (Item03 - Usar reflection). N�s aprendemos aqui na classe programa que � poss�vel em v�rias tarefas utilizar o reflection para, por exemplo, obter o tipo de um relat�rio, de uma determinada classe, obter quais s�o os membros de um relat�rio, onde os membros s�o, por exemplo, campo, m�todo e propriedades.

Aprendemos a modificar o nome de um objeto do nosso relat�rio via reflection, que pode ser uma maneira alternativa de modificar uma propriedade. N�s aprendemos, tamb�m, a descobrir quais s�o os tipos que fazem parte de um assembly. E aprendemos tamb�m a utilizar o LINQ, que s�o as consultas integradas a linguagem para poder varrer os tipos de um assembly, para poder fazer uma consulta mais enxuta, mais elegante para poder utilizar reflection.

<img src="Image07.png" />

<img src="Image08.png" />

E, continuando, n�s fomos l� para o Item04, que � gerar o c�digo em tempo de execu��o. Ent�o, n�s aprendemos a fazer um programinha aqui no Item04 gera��o de c�digo. E esse programa cria aqui um namespace chamado recursos humanos e l� dentro ele declara uma classe funcion�rio com alguns campos, nome e sal�rio, e tamb�m o construtor. Ent�o n�s utilizamos aqui atrav�s da gera��o de c�digo, chamado CodeDOM, ou objetos do modelo de c�digo do dot net, para a gente poder declarar v�rios tipos de objetos, para poder montar cada parte desse c�digo aqui, o c�digo do namespace recursos humanos.

<img src="Image09.png" />

E l� no final, na �ltima parte, a gente aprendeu a utilizar os tipos do namespace System.Reflection. Ent�o, n�s j� t�nhamos visto algumas coisas sobre o reflection. E aprendemos a nos aprofundar nesse nesse tema.

Aqui no Item05 n�s aprendemos a criar um programa que faz uma s�rie de investiga��es, como, por exemplo, obter qual � a vers�o do assembly, qual � a vers�o maior, a vers�o menor, para descobrir tamb�m se um determinado assembly est� ou n�o no cache de assembly global, para descobrir os objetos, que s�o os m�dulos, os tipos e, tamb�m, os membros desses objetos que est�o no assembly.

Ent�o � isso, espero que voc�s tenham gostado do curso. N�o deixem de participar do f�rum, em caso de sugest�es ou d�vidas. Muito obrigado e at� a pr�xima.

<img src="Image10.png" />
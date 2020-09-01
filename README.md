# TailLogResult
Projeto para rastrear log e executar um comando quando linha esperada for encontrada.

O sistema tem como objetivo fazer a leitura constante de um log, por um tempo definido na configuração. 
Caso encontrado, o sistema executa uma linha de comando no cmd, a linha tambem configurada.

Estrutura da configuração do Aplicativo.
{
  "FilePath": "C:\\Users\\Kelvyn\\Documents\\TestTailLogResult\\Novo Documento de Texto.txt",   -> Caminho do Log
  "ExpectedLogLine": "Finalizar",     ->Linha esperada de encontrar no log 
  "Timeout": {                        ->Tempo que o aplicativo vai ficar monitorando o log
    "Hours": 0,
    "Minutes": 0,
    "Seconds": 30
  },      
  "FileLenght": 10,                                     ->Tamanho do fim ao começo que app vai ler o log. Por exemplo, ele sempre lerá a ultima linha do log se assim configurado.
  "ExecuteCommand": true,                               -> indica se apos encontrar a linha do log, executa o comando ou não.
  "CommandToExecute": "echo validacao diferenciada d+"  ->Comando a ser executado após encontrar a linha
}


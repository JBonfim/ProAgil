export interface Evento {

     id: number;

     local: string;

     dataEvento: Date;

     tema: string;

     qtdPessoas: number;

     telefone: string;

     email: string;

     imagemUrl: string;

     lotes: Lote[];

     redesociais: RedeSocial[];

     palestrateEventos: PalestrateEvento[];

     
}

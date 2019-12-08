import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.css']
})

export class EventosComponent implements OnInit {

  _FILTROLISTA: string;

  get filtroLista(): string {
    return this._FILTROLISTA;
  }
  set filtroLista(value: string){
    this._FILTROLISTA = value;
    this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this.filtroLista) : this.eventos;
  }


  eventosFiltrados: any = [];
  eventos: any = [] ;
  imagemLargura = 50;
  imagemMargem = 2;
  mostrarImg = false;

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getEventos();
  }

  filtrarEventos(filtrarPor: string): any{
    filtrarPor = filtrarPor.toLocaleLowerCase();
    console.log(filtrarPor);
    return this.eventos.filter(
      evento => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }

  mostrarImagem(){
    this.mostrarImg = !this.mostrarImg;
  }

  getEventos() {
    this.http. get('http://localhost:5000/api/values').subscribe(response => {
      this.eventos = response;
      console.log(this.eventos);
    }, error => {
      console.log(error);
    });
  }

}

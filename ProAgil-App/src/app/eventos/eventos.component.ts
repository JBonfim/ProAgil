import { Component, OnInit, TemplateRef } from '@angular/core';
import { EventoService } from '../_services/evento.service';
import { Evento } from '../_models/Evento';
import { BsModalRef, BsModalService } from 'ngx-bootstrap';


@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.css']
})

export class EventosComponent implements OnInit {

  
  eventosFiltrados: Evento[];
  eventos: Evento[] ;
  imagemLargura = 50;
  imagemMargem = 2;
  mostrarImg = false;

  modalRef: BsModalRef;

  _FILTROLISTA: string;

  constructor(
    private eventoService: EventoService
    , private modalService: BsModalService
    ) { }

  get filtroLista(): string {
    return this._FILTROLISTA;
  }
  set filtroLista(value: string){
    this._FILTROLISTA = value;
    this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this.filtroLista) : this.eventos;
  }



  OpenModal(template: TemplateRef<any>){
    this.modalRef = this.modalService.show(template);
  }  

  ngOnInit() {
    //Inicializa os parametros
    this.getEventos();
  }

  filtrarEventos(filtrarPor: string): Evento[]{
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
    this.eventoService.getAllEvento().subscribe(
      (_Eventos: Evento[]) => {
      this.eventos = _Eventos;
      this.eventosFiltrados = this.eventos;
      console.log(this.eventos);
    }, error => {
      console.log(error);
    });
  }

}

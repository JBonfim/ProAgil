import { Component, OnInit, TemplateRef } from '@angular/core';
import { EventoService } from '../_services/evento.service';
import { Evento } from '../_models/Evento';
import { BsModalRef, BsModalService } from 'ngx-bootstrap';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { defineLocale,BsLocaleService,ptBrLocale } from 'ngx-bootstrap';
defineLocale('pt-br',ptBrLocale);

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
  registerForm: FormGroup;

  modalRef: BsModalRef;

  _FILTROLISTA: string;

  constructor(
    private eventoService: EventoService
    , private modalService: BsModalService
    ,private fb: FormBuilder
    ,private localeService: BsLocaleService
    ) {
      this.localeService.use('pt-br');
     }

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
    this.validation();
    this.getEventos();
  }

  /*validation(){
    this.registerForm = new FormGroup({
      tema: new FormControl('',
        [Validators.required,Validators.minLength(4),Validators.maxLength(40)]),
      local: new FormControl('',Validators.required),
      dataEvento: new FormControl('',Validators.required),
      qtdPessoas: new FormControl('',
        [Validators.required,Validators.maxLength(120000)]),
      imagemUrl: new FormControl('',Validators.required),
      telefone: new FormControl('',Validators.required),
      email: new FormControl('',
        [Validators.required,Validators.email])
    });
  }*/

  validation(){
    this.registerForm = this.fb.group({
      tema: ['',[Validators.required,Validators.minLength(4),Validators.maxLength(40)]],
      local: ['',Validators.required],
      dataEvento: ['',Validators.required],
      qtdPessoas: ['', [Validators.required,Validators.maxLength(120000)]],
      imagemUrl: ['',Validators.required],
      telefone: ['',Validators.required],
      email: ['',
        [Validators.required,Validators.email]]
    });
  }

  salvarAlteracao(){

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

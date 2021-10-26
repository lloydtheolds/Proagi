import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';


@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.css']
})
export class EventosComponent implements OnInit {

  _filtroLista: string;
  eventosFiltrados: any = [];
  eventos: any = [];
  imagemLargura = 50;
  imagemMargem = 2;

  mostrarImagem = true;

 
  
  get filtroLista(): string{
        return this._filtroLista;
  }
  
 set filtroLista(value : string) {
    this._filtroLista = value;
    this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this.filtroLista): this.eventos;
  }
  
  
  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getEventos()
  }

  filtrarEventos(filtrarPor: string): any{
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.eventos.filter(
      evento => 
    evento.eventoId == filtrarPor ||
    evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1 || 
    evento.local.toLocaleLowerCase().indexOf(filtrarPor) !== -1|| 
    evento.qtdPessoas == filtrarPor
      );
  }

  alternarImagem(){
    this.mostrarImagem = !this.mostrarImagem;
  }
  getEventos(){
    this.http.get('http://localhost:5000/prodest/values').subscribe(response => {
      this.eventos = response;
      console.log(response); 
    }, error => {
      console.log(error);
    }

    );
  }

}
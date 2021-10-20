import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.css']
})
export class EventosComponent implements OnInit {

  eventos: any =[
    {
      EventoId: 1,
      Tema: 'Lor',
      Lugar: 'Cariacica'
    },
    {
      EventoId: 2,
      Tema: 'Castlevania',
      Lugar: 'Serra'
    },
    {
      EventoId: 3,
      Tema: 'Osu',
      Lugar: 'Viana'
    }

  ]

  constructor() { }

  ngOnInit() {
  }

}

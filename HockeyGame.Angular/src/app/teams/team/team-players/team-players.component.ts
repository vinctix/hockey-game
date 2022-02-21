import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Player } from 'src/app/shared/models/player.model';
import { PlayersService } from 'src/app/shared/services/players.service';

@Component({
  selector: 'app-team-players',
  templateUrl: './team-players.component.html',
  styles: [`
    :host { 
      display: flex; 
    }
    table {
      width: 100%;
    }
    .captain-icon {
      width: 30px;
    }
    .captain-icon-small {
      width: 20px;
      height: 20px;
    }
  `]
})
export class TeamPlayersComponent implements OnInit {
  
  @Input() players!: Player[];
  @Output() captainChanged = new EventEmitter<Player>();
  
  readonly displayedColumns: string[] = ['firstName', 'lastName', 'number', 'position', 'isCaptain', 'actions'];

  constructor(private playersService: PlayersService) { }

  ngOnInit(): void {
  }

  setCaptain(id: number) {
    this.playersService.setCaptain$(id).subscribe(x => this.captainChanged.emit(x));
  }


}

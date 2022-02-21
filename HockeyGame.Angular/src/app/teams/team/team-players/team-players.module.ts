import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TeamPlayersComponent } from './team-players.component';
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { MatMenuModule } from '@angular/material/menu';
import { MatIconModule } from '@angular/material/icon';

@NgModule({
  declarations: [
    TeamPlayersComponent
  ],
  imports: [
    CommonModule,
    MatTableModule,
    MatButtonModule,
    MatMenuModule,
    MatIconModule
  ],
  exports: [TeamPlayersComponent]

})
export class TeamPlayersModule { }

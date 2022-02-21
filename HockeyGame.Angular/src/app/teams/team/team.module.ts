import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TeamComponent } from './team.component';
import { MatButtonModule } from '@angular/material/button';
import { AddTeamMemberModule } from '../add-team-member/add-team-member.module';
import { TeamPlayersModule } from './team-players/team-players.module';


@NgModule({
  declarations: [
    TeamComponent,
  ],
  imports: [
    CommonModule,
    MatButtonModule,
    AddTeamMemberModule,
    TeamPlayersModule
  ],
  exports: [
    TeamComponent
  ]
})
export class TeamModule { }

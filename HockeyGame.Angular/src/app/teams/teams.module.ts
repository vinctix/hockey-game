import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TeamsComponent } from './teams.component';
import { TeamSelectorModule } from './team-selector/team-selector.module';
import { TeamsRoutingModule } from './teams-routing.module';
import { TeamModule } from './team/team.module';



@NgModule({
  declarations: [
    TeamsComponent
  ],
  imports: [
    CommonModule,
    TeamsRoutingModule,
    TeamSelectorModule,
    TeamModule
  ],
  exports: [
    TeamsComponent
  ]
})
export class TeamsModule { }

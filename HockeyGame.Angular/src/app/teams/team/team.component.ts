import { Component, Input, OnInit } from '@angular/core';
import { Team } from 'src/app/shared/models/team.model';
import { TeamsService } from 'src/app/shared/services/teams.service';

@Component({
  selector: 'app-team',
  templateUrl: './team.component.html',
  styleUrls: ['./team.component.css']
})
export class TeamComponent implements OnInit {

  @Input() team!: Team;

  isAddingPlayer = false;

  constructor(private teamsService: TeamsService) { }

  ngOnInit(): void {
  }

  onAddingPlayerFinished(isCreationDone: boolean) {
    if(isCreationDone) {
      this.refreshTeam();
    }
    this.isAddingPlayer = false;
  }

  refreshTeam() {
    this.teamsService.getTeamByYear$(this.team.year).subscribe(x => this.team = x);
  }

}

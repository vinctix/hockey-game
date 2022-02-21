import { Component, EventEmitter, OnDestroy, OnInit, Output } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { delay, finalize, Subject, takeUntil } from 'rxjs';
import { Team } from 'src/app/shared/models/team.model';
import { TeamsService } from 'src/app/shared/services/teams.service';

@Component({
  selector: 'app-team-selector',
  templateUrl: './team-selector.component.html',
  styleUrls: ['./team-selector.component.css']
})
export class TeamSelectorComponent implements OnInit, OnDestroy {

  @Output() teamSelected = new EventEmitter<Team | undefined>();

  form!: FormGroup;
  readonly isLoading$ = new Subject<boolean>();
  private readonly unsubscribe$ = new Subject<void>();
  isTeamNotFound = false;

  constructor(private fb: FormBuilder, private teamsService: TeamsService) { }
  
  ngOnInit(): void {
    this.form = this.createForm();
    this.disableFcYearWhenIsLoading();
  }

  ngOnDestroy(): void {
    this.unsubscribe$.next();
    this.unsubscribe$.complete();
  }

  private createForm(): FormGroup {
    return this.fb.group({
      year: ['', Validators.required]
    });
  }

  private disableFcYearWhenIsLoading() {
    this.isLoading$.pipe(
      takeUntil(this.unsubscribe$)
    ).subscribe(isLoading => {
      if(isLoading && this.fcYear.enabled) {
        this.fcYear.disable();
      } else if(!isLoading && this.fcYear.disabled) {
        this.fcYear.enable();
      }
    });
  }

  get fcYear(): AbstractControl {
    return this.form.get('year') as AbstractControl;
  }

  search() {
    const year = this.fcYear.value;
    this.isLoading$.next(true);
    this.teamsService.getTeamByYear$(year)
      .pipe(
        finalize(() => this.isLoading$.next(false)),
      )
      .subscribe({ 
        next: x => this.onTeamFound(x),
        error: () => this.onTeamNotFound()
      });
  }

  private onTeamFound(team: Team) {
    this.teamSelected.emit(team);
    this.isTeamNotFound = false;
  }

  private onTeamNotFound() {
    this.isTeamNotFound = true;
    this.teamSelected.next(undefined);
  }
}

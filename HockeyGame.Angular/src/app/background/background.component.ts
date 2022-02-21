import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-background',
  template: '<ng-content></ng-content>',
  styles: [`:host {
    height: 2200px;
    width: 3000px;
    background-size:cover;
    background-image:url('/assets/images/background.jpeg');
    background-position:50% 50%;
  }`]
})
export class BackgroundComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}

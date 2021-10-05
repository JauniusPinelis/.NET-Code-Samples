import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-points',
  templateUrl: './points.component.html',
  styleUrls: ['./points.component.css']
})
export class PointsComponent implements OnInit {

  public points = [
    {x: 2, y: 5},
    {x: 6, y: 9},
    {x: 1, y: 1},
  ];
  public title:string = "Points";

  constructor() { }

  ngOnInit(): void {
   
  }

  public addPoint() : void {
    this.points.push({x:3, y: 5});
  }

}

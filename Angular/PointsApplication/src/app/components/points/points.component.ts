import { Component, OnInit } from '@angular/core';
import { Point } from 'src/app/models/point';
import { PointsService } from 'src/app/services/points.service';

@Component({
  selector: 'app-points',
  templateUrl: './points.component.html',
  styleUrls: ['./points.component.css']
})
export class PointsComponent implements OnInit {

  private pointsService: PointsService;

  public x: number = 0;
  public y: number = 0;

  public points: Point[] = [
    {x: 2, y: 5},
    {x: 6, y: 9},
    {x: 1, y: 1},
  ];
  public title:string = "Points";

  constructor(pointsService: PointsService) {
    this.pointsService = pointsService;
   }

  ngOnInit(): void {
    this.pointsService.GetPoints().subscribe((pointsFromApi) =>{
      this.points = pointsFromApi;
    })
  }

  public addPoint() : void {
    var newPoint: Point = {
      x: this.x,
      y: this.y
    }

    this.pointsService.AddPoint(newPoint).subscribe(() => {
      this.points.push(newPoint);
    });
  }

}

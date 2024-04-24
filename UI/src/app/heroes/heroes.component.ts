import { Component, OnInit } from '@angular/core';
import { Hero } from '../hero';
import { HeroService } from '../data/hero.service';


@Component({
  selector: 'app-heroes',
  templateUrl: './heroes.component.html',
  styleUrl: './heroes.component.css'
})

export class HeroesComponent implements OnInit { // Add OnInit
  heroes: Hero[] = [];
  selectedHero: Hero | undefined;

  onSelect(hero: Hero): void {
    this.selectedHero = hero;
}

  constructor(private heroService: HeroService) {}

  ngOnInit(): void {
      this.getHeroes();
  }

  getHeroes(): void {
      this.heroService.getHeroes()
          .subscribe(heroes => this.heroes = heroes);
  }

}

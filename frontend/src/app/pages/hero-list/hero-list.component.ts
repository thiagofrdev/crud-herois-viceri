import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeroService } from '../../services/hero.service';
import { Hero } from '../../models/hero.model';
import { HeroCardComponent } from "../../components/hero-card/hero-card.component";
import { Router } from '@angular/router';

@Component({
  selector: 'app-hero-list',
  standalone: true,
  imports: [CommonModule, HeroCardComponent],
  templateUrl: './hero-list.component.html',
  styleUrl: './hero-list.component.scss'
})
export class HeroListComponent implements OnInit{
  heroes: Hero[] = [];

  constructor(private heroService: HeroService, private router: Router) { }

  ngOnInit(): void {
    this.heroService.getHeroes().subscribe(result => {
      this.heroes = result;
    });
  }

  handleDelete(heroId: number): void {
    if (confirm('Tem certeza que deseja excluir este herói?')) {
      this.heroService.deleteHero(heroId).subscribe(() => {
        this.heroes = this.heroes.filter(hero => hero.id !== heroId);
      });
    }
  }

  handleEdit(heroId: number): void {
      this.router.navigate(['/heroes/edit', heroId]);
    }
}

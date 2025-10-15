import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeroService } from '../../services/hero.service';
import { Hero } from '../../models/hero.model';
import { HeroFormUiComponent } from "../../components/hero-form-ui/hero-form-ui.component";
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-hero-form',
  standalone: true,
  imports: [CommonModule, HeroFormUiComponent],
  templateUrl: './hero-form.component.html',
  styleUrl: './hero-form.component.scss'
})
export class HeroFormComponent implements OnInit{
  hero?: Hero;
  isEditMode = false;
  heroIdForEdit: number | null = null;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private heroService: HeroService
  ) {}

  ngOnInit(): void {
    const heroId = this.route.snapshot.paramMap.get('id')

    if (heroId) {
      this.isEditMode = true
      this.heroIdForEdit = +heroId;
      this.heroService.getHeroByID(+heroId).subscribe(hero => {
        this.hero = hero;
      });
    }
  }

  onSave(heroData: any): void {
    if (this.isEditMode && this.heroIdForEdit) {
      this.heroService.updateHero(this.heroIdForEdit, heroData).subscribe(() => {
        this.router.navigate(['/heroes']);
      });
    } else {
      this.heroService.createHero(heroData).subscribe(() => {
        this.router.navigate(['/heroes']);
      });
    }
  }
}

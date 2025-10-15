import { Component, Input, Output, EventEmitter } from '@angular/core';
import { Hero } from '../../models/hero.model';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-hero-card',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './hero-card.component.html',
  styleUrl: './hero-card.component.scss'
})
export class HeroCardComponent {
  @Input() hero!: Hero;

  @Output() delete = new EventEmitter<number>();
  @Output() edit = new EventEmitter<number>();

  onDeleteClick(): void {
    this.delete.emit(this.hero.id);
  }

  onEditClick(): void {
    this.edit.emit(this.hero.id);
  }
}

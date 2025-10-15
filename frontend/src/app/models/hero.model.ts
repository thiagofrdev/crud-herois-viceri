import { Superpoder } from "./superpoder.model";

export interface Hero{
    id: number;
    nome: string;
    nomeHeroi: string;
    altura: number;
    peso: number;
    superpoderes: Superpoder[]
}
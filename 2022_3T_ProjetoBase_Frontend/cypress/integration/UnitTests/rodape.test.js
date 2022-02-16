describe("Componente - Rodapé", () => {

    // Pré-Condiçaõ
    // Abrir o navegador antes de tudo
    beforeEach(() => {
        cy.visit('http://localhost:3000')
    })

    // Descrição
    it("Deve existir uma tag footer no corpo do documento", () => {
        
        // Pré-Condição

        // Procedimento
        cy.get('footer').should('exist')

        // Resultado esperado
    })

    it("Deve conter o texto Escola Senai de Informatica", () => {
        cy.get('.rodapePrincipal section div p').should('have.text', 'Escola SENAI de Informática - 2021')
    })

    it("Deve verificar se footer está visível e se possuí uma classe chamada rodapePrincipal", () => {
        cy.get('footer').should('be.visible').and('have.class', 'rodapePrincipal')
    })
})
